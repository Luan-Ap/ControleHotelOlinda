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
    public class HospedagemRepository : IHospedagemRepository
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IQuartoRepository _quartoRepository;

        public HospedagemRepository()
        {
            _clienteRepository = new ClienteRepository();
            _quartoRepository = new QuartoRepository();
        }

        public Hospedagem GetHospedagemByCod(Guid? cod)
        {
            Hospedagem hospedagem = null;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_HOSPEDAGENS_COD";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", cod);

                Cliente cliente = null;
                Quarto quarto = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            hospedagem = new Hospedagem(cod: Guid.Parse(dr["Cod_Hosp"].ToString()), codCliente: Guid.Parse(dr["Cod_Cliente"].ToString()), cliente: null, entrada: Convert.ToDateTime(dr["Entrada"]), saida: Convert.ToDateTime(dr["Saida"]), codQuarto: Guid.Parse(dr["Cod_Quarto"].ToString()), quarto: null, consumo: Convert.ToDouble(dr["Consumo"]), ativo: Convert.ToBoolean(dr["Ativo_Hospe"]));

                            cliente = _clienteRepository.GetClienteByCod(hospedagem.CodCliente);
                            quarto = _quartoRepository.GetQuartoByCod(hospedagem.CodQuarto);

                            hospedagem.AdicionarComplemento(cliente);
                            hospedagem.AdicionarComplemento(quarto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return hospedagem;
        }

        public Hospedagem GetHospedagemForCheckOut(string cpf)
        {
            Hospedagem hospedagem = null;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_HOSPEDAGEM_CHECKOUT";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cpf", cpf);

                Cliente cliente = null;
                Quarto quarto = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            hospedagem = new Hospedagem(cod: Guid.Parse(dr["Cod_Hosp"].ToString()), codCliente: Guid.Parse(dr["Cod_Cliente"].ToString()), cliente: null, entrada: Convert.ToDateTime(dr["Entrada"]), saida: Convert.ToDateTime(dr["Saida"]), codQuarto: Guid.Parse(dr["Cod_Quarto"].ToString()), quarto: null, consumo: Convert.ToDouble(dr["Consumo"]), ativo: Convert.ToBoolean(dr["Ativo_Hospe"]));

                            cliente = _clienteRepository.GetClienteByCod(hospedagem.CodCliente);
                            quarto = _quartoRepository.GetQuartoByCod(hospedagem.CodQuarto);

                            hospedagem.AdicionarComplemento(cliente);
                            hospedagem.AdicionarComplemento(quarto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return hospedagem;
        }

        public IEnumerable<Hospedagem> GetHospedagens()
        {
            List<Hospedagem> hospedagens = new();

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_HOSPEDAGENS";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                Hospedagem hospedagem = null;
                Cliente cliente = null;
                Quarto quarto = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            hospedagem = new Hospedagem(cod: Guid.Parse(dr["Cod_Hosp"].ToString()), codCliente: Guid.Parse(dr["Cod_Cliente"].ToString()), cliente: null, entrada: Convert.ToDateTime(dr["Entrada"]), saida: Convert.ToDateTime(dr["Saida"]), codQuarto: Guid.Parse(dr["Cod_Quarto"].ToString()), quarto: null, consumo: Convert.ToDouble(dr["Consumo"]), ativo: Convert.ToBoolean(dr["Ativo_Hospe"]));

                            cliente = _clienteRepository.GetClienteByCod(hospedagem.CodCliente);
                            quarto = _quartoRepository.GetQuartoByCod(hospedagem.CodQuarto);

                            hospedagem.AdicionarComplemento(cliente);
                            hospedagem.AdicionarComplemento(quarto);

                            hospedagens.Add(hospedagem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return hospedagens;
        }

        public IEnumerable<Hospedagem> GetHospedagensByStatus(bool status)
        {
            List<Hospedagem> hospedagens = new();

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_HOSPEDAGENS_STATUS";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Ativo", status);

                Hospedagem hospedagem = null;
                Cliente cliente = null;
                Quarto quarto = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            hospedagem = new Hospedagem(cod: Guid.Parse(dr["Cod_Hosp"].ToString()), codCliente: Guid.Parse(dr["Cod_Cliente"].ToString()), cliente: null, entrada: Convert.ToDateTime(dr["Entrada"]), saida: Convert.ToDateTime(dr["Saida"]), codQuarto: Guid.Parse(dr["Cod_Quarto"].ToString()), quarto: null, consumo: Convert.ToDouble(dr["Consumo"]), ativo: Convert.ToBoolean(dr["Ativo_Hospe"]));

                            cliente = _clienteRepository.GetClienteByCod(hospedagem.CodCliente);
                            quarto = _quartoRepository.GetQuartoByCod(hospedagem.CodQuarto);

                            hospedagem.AdicionarComplemento(cliente);
                            hospedagem.AdicionarComplemento(quarto);

                            hospedagens.Add(hospedagem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return hospedagens;
        }

        public bool SavaHospedagem(Hospedagem hospedagem)
        {
            bool hospedagemInserida;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();

                SqlTransaction transaction;
                var comando = "SP_INICIAR_HOSPEDAGEM";

                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", hospedagem.Codigo);
                cm.Parameters.AddWithValue("@Cod_Cliente", hospedagem.CodCliente);
                cm.Parameters.AddWithValue("@Cod_Quarto", hospedagem.CodQuarto);
                cm.Parameters.AddWithValue("@Data_Entrada", hospedagem.DataEntrada.Date.ToUniversalTime());
                cm.Parameters.AddWithValue("@Data_Saida", hospedagem.DataSaida.Date.ToUniversalTime());
                cm.Parameters.AddWithValue("@Ativo", hospedagem.Ativo);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    hospedagemInserida = true;
                }
                catch
                {
                    transaction.Rollback();
                    hospedagemInserida = false;
                }
            }

            return hospedagemInserida;
        }
    }
}
