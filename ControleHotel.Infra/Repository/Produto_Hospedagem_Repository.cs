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
    public class Produto_Hospedagem_Repository : IProduto_Hospedagem_Repository
    {
        private readonly IHospedagemRepository _hospedagemRepository;
        private readonly IProdutoRepository _produtoRepository;

        public Produto_Hospedagem_Repository()
        {
            _hospedagemRepository = new HospedagemRepository();
            _produtoRepository = new ProdutoRepository();
        }

        public IEnumerable<Produto_Hospedagem> GetConsumosByHospedagem(Guid? cod)
        {
            List<Produto_Hospedagem> consumos = new();

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_CONSUMOS_HOSPEDAGEM";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", cod);

                Produto_Hospedagem prodHosp = null;
                Hospedagem hospedagem = null;
                Produto produto = null;

                try
                {
                    conn.Open();

                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            prodHosp = new Produto_Hospedagem(cod: Guid.Parse(dr["Cod_Consumo"].ToString()), codHosp: Guid.Parse(dr["Cod_Hospedagem"].ToString()), hosp: null, codProd: Guid.Parse(dr["Cod_Produto"].ToString()), produto: null, qtd: Convert.ToInt32(dr["Qtd_Consumida"]), total: Convert.ToDouble(dr["Valor_Total"]), dataConsumo: Convert.ToDateTime(dr["Data_Consumo"]), ativo: Convert.ToBoolean(dr["Ativo_Consumo"]));

                            hospedagem = _hospedagemRepository.GetHospedagemByCod(prodHosp.CodHospedagem);
                            produto = _produtoRepository.GetProdutoByCod(prodHosp.CodProduto);

                            prodHosp.AdicionarComplemento(hospedagem);
                            prodHosp.AdicionarComplemento(produto);

                            consumos.Add(prodHosp);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return consumos;
        }

        public bool SaveConsumos(Produto_Hospedagem prodHosp)
        {
            bool consumoInserido;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();

                SqlTransaction transaction;
                var comando = "SP_HOSPEDAGEM_INSERIR_CONSUMOS";

                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod_Consumo", prodHosp.Codigo);
                cm.Parameters.AddWithValue("@Cod_Hospedagem", prodHosp.CodHospedagem);
                cm.Parameters.AddWithValue("@Cod_Produto", prodHosp.CodProduto);
                cm.Parameters.AddWithValue("@Tipo", prodHosp.Produto.TipoProduto.ToString());
                cm.Parameters.AddWithValue("@Qtd_Consumida", prodHosp.QuantidadeConsumida);
                cm.Parameters.AddWithValue("@Valor_Total", prodHosp.ValorTotal);
                cm.Parameters.AddWithValue("@Data_Consumo", prodHosp.DataConsumo.Date.ToUniversalTime());
                cm.Parameters.AddWithValue("@Ativo", prodHosp.Ativo);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    consumoInserido = true;
                }
                catch
                {
                    transaction.Rollback();
                    consumoInserido = false;
                }
            }

            return consumoInserido;
        }
    }
}
