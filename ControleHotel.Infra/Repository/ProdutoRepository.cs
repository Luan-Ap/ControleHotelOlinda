using ControleHotel.Dominio.Entidades;
using ControleHotel.Dominio.Interfaces.Repository;
using ControleHotel.Infra.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public bool DesativarProduto(Guid? cod)
        {
            bool produtoDesativado;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction;

                var comando = "UPDATE Produto SET Ativo = 0 WHERE Codigo = @Cod";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.Text
                };

                cm.Parameters.AddWithValue("@Cod", cod);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    produtoDesativado = true;
                }
                catch
                {
                    transaction.Rollback();
                    produtoDesativado = false;
                }
            }

            return produtoDesativado;
        }

        public Produto GetProdutoByCod(Guid? cod)
        {
            Produto produto = null;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_PRODUTOS_COD";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", cod);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            produto = new Produto(cod: Guid.Parse(dr["Codigo"].ToString()), nome: dr["Nome"].ToString(), qtd: Convert.ToInt32(dr["Qtd"]), valor: Convert.ToDouble(dr["Valor"]), tipo: (TipoProduto)Enum.Parse(typeof(TipoProduto), dr["Tipo"].ToString()), dataCadastro: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Prod"]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return produto;
        }

        public IEnumerable<Produto> GetProdutos()
        {
            List<Produto> produtos = new();

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_PRODUTOS";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                Produto produto = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            produto = new Produto(cod: Guid.Parse(dr["Codigo"].ToString()), nome: dr["Nome"].ToString(), qtd: Convert.ToInt32(dr["Qtd"]), valor: Convert.ToDouble(dr["Valor"]), tipo: (TipoProduto)Enum.Parse(typeof(TipoProduto), dr["Tipo"].ToString()), dataCadastro: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Prod"]));

                            produtos.Add(produto);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return produtos;
        }

        public IEnumerable<Produto> GetProdutosByTipo(string tipo)
        {
            List<Produto> produtos = new();

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_PRODUTOS_TIPO";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Tipo", tipo);

                Produto produto = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            produto = new Produto(cod: Guid.Parse(dr["Codigo"].ToString()), nome: dr["Nome"].ToString(), qtd: Convert.ToInt32(dr["Qtd"]), valor: Convert.ToDouble(dr["Valor"]), tipo: (TipoProduto)Enum.Parse(typeof(TipoProduto), dr["Tipo"].ToString()), dataCadastro: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Prod"]));

                            produtos.Add(produto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return produtos;
        }

        public bool SaveProduto(Produto produto)
        {
            bool produtoInserido;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction;

                var comando = "SP_INSERIR_PRODUTO";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", produto.Codigo);
                cm.Parameters.AddWithValue("@Nome", produto.Nome);
                cm.Parameters.AddWithValue("@Tipo_Produto", produto.TipoProduto.ToString());
                cm.Parameters.AddWithValue("@Valor", produto.Valor);
                cm.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                cm.Parameters.AddWithValue("@Data_Cadastro", produto.DataCadastro.Date.ToUniversalTime());
                cm.Parameters.AddWithValue("@Ativo", produto.Ativo);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    produtoInserido = true;
                }
                catch
                {
                    transaction.Rollback();
                    produtoInserido = false;
                }
                
            }

            return produtoInserido;
        }

        public bool UpdateProduto(Produto produto)
        {
            bool produtoAtualizado;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction;

                var comando = "UPDATE Produto SET Nome = @Nome, Quantidade = @Qtd, Valor = @Valor WHERE Codigo = @Cod";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.Text
                };

                cm.Parameters.AddWithValue("@Nome", produto.Nome);
                cm.Parameters.AddWithValue("@Qtd", produto.Quantidade);
                cm.Parameters.AddWithValue("@Valor", produto.Valor);
                cm.Parameters.AddWithValue("@Cod", produto.Codigo);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    produtoAtualizado = true;
                }
                catch
                {
                    transaction.Rollback();
                    produtoAtualizado = false;
                }
            }

            return produtoAtualizado;
        }
    }
}
