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
    public class QuartoRepository : IQuartoRepository
    {
        private readonly ITipoQuartoRepository _tipoQuartoRepository;

        public QuartoRepository()
        {
            _tipoQuartoRepository = new TipoQuartoRepository();
        }

        public bool DesativarQuarto(Guid? cod)
        {
            bool quartoDesativado;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();

                SqlTransaction transaction;
                var comando = "UPDATE Quarto SET Ativo = 0 WHERE Codigo = @Cod";
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
                    quartoDesativado = true;
                }
                catch
                {
                    transaction.Rollback();
                    quartoDesativado = false;
                }
            }

            return quartoDesativado;
        }

        public Quarto GetQuartoByCod(Guid? cod)
        {
            Quarto quarto = null;

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_QUARTO_COD";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", cod);

                TipoQuarto tipoQuarto = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            quarto = new Quarto(cod: Guid.Parse(dr["Cod_Quarto"].ToString()), num: Convert.ToInt32(dr["Num"]), descricao: dr["Descricao"].ToString(), tipoId: Guid.Parse(dr["Cod_Tipo"].ToString()), tipo: null, dataCadastro: Convert.ToDateTime(dr["Data_Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Quarto"]));

                            tipoQuarto = _tipoQuartoRepository.GetTipoQuartoByCod(quarto.CodTipoQuarto);

                            quarto.AdicionarComplemento(tipoQuarto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }

            return quarto;
        }

        public IEnumerable<Quarto> GetQuarto()
        {
            List<Quarto> quartos = new();

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_LISTAR_QUARTOS";
                SqlCommand cm = new SqlCommand(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                Quarto quarto = null;
                TipoQuarto tipo = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            quarto = new Quarto(cod: Guid.Parse(dr["Cod_Quarto"].ToString()), num: Convert.ToInt32(dr["Num"]), descricao: dr["Descricao"].ToString(), tipoId: Guid.Parse(dr["Cod_Tipo"].ToString()), tipo: null, dataCadastro: Convert.ToDateTime(dr["Data_Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Quarto"]));

                            tipo = _tipoQuartoRepository.GetTipoQuartoByCod(quarto.CodTipoQuarto);

                            quarto.AdicionarComplemento(tipo);

                            quartos.Add(quarto);

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return quartos;
        }

        public IEnumerable<Quarto> GetQuartoByTipo(string tipo)
        {
            List<Quarto> quartos = null;

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_LISTAR_QUARTOS_TIPO";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Tipo", tipo);

                Quarto quarto = null;
                TipoQuarto tipoQuarto = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            quarto = new Quarto(cod: Guid.Parse(dr["Cod_Quarto"].ToString()), num: Convert.ToInt32(dr["Num"]), descricao: dr["Descricao"].ToString(), tipoId: Guid.Parse(dr["Cod_Tipo"].ToString()), tipo: null, dataCadastro: Convert.ToDateTime(dr["Data_Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Quarto"]));

                            tipoQuarto = _tipoQuartoRepository.GetTipoQuartoByCod(quarto.CodTipoQuarto);

                            quarto.AdicionarComplemento(tipoQuarto);

                            quartos.Add(quarto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return quartos;
        }

        public bool SaveQuarto(Quarto quarto)
        {
            bool quartoInserido;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();

                SqlTransaction transaction;
                var comando = "SP_CADASTRAR_QUARTO";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", quarto.Codigo);
                cm.Parameters.AddWithValue("@Num_Quarto", quarto.NumQuarto);
                cm.Parameters.AddWithValue("@Descricao", quarto.Descricao);
                cm.Parameters.AddWithValue("@Cod_Tipo_Quarto", quarto.CodTipoQuarto);
                cm.Parameters.AddWithValue("@Data_Cadastro", quarto.DataCadastro.Date.ToUniversalTime());
                cm.Parameters.AddWithValue("@Ativo", quarto.Ativo);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    quartoInserido = true;
                }
                catch
                {
                    transaction.Rollback();
                    quartoInserido = false;
                }
            }

            return quartoInserido;
        }

        public bool UpdateQuarto(Quarto quarto)
        {
            bool quartoAtualizado;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();

                SqlTransaction transaction;
                var comando = "UPDATE Quarto SET Num_Quarto = @Num_Quarto, Descricao = @Descricao WHERE Codigo = @Cod";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.Text
                };

                cm.Parameters.AddWithValue("@Cod", quarto.Codigo);
                cm.Parameters.AddWithValue("@Num_Quarto", quarto.NumQuarto);
                cm.Parameters.AddWithValue("@Descricao", quarto.Descricao);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    quartoAtualizado = true;
                }
                catch
                {
                    transaction.Rollback();
                    quartoAtualizado = false;
                }
            }

            return quartoAtualizado;
        }

        public IEnumerable<Quarto> GetQuartosDisponiveis(DateTime entrada, DateTime saida, Guid codTipo)
        {
            List<Quarto> quartos = new();

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_CONSULTAR_OFERTAS";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", codTipo);
                cm.Parameters.AddWithValue("@Inicio", entrada);
                cm.Parameters.AddWithValue("@Fim", saida);

                Quarto quarto = null;
                TipoQuarto tipoQuarto = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            quarto = new Quarto(cod: Guid.Parse(dr["Cod_Quarto"].ToString()), num: Convert.ToInt32(dr["Num"]), descricao: dr["Descricao"].ToString(), tipoId: Guid.Parse(dr["Cod_Tipo"].ToString()), tipo: null, dataCadastro: Convert.ToDateTime(dr["Data_Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Quarto"]));

                            tipoQuarto = _tipoQuartoRepository.GetTipoQuartoByCod(quarto.CodTipoQuarto);

                            quarto.AdicionarComplemento(tipoQuarto);

                            quartos.Add(quarto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return quartos;
        }
    }
}
