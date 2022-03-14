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
    public class ReservaRepository : IReservaRepository
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IQuartoRepository _quartoRepository;

        public ReservaRepository()
        {
            _clienteRepository = new ClienteRepository();
            _quartoRepository = new QuartoRepository();
        }

        public bool CancelarReserva(Guid? codReserva, RegistroPagamento registro = null)
        {
            bool reservaCancelada;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();

                SqlTransaction transaction;
                SqlCommand cm = new()
                {
                    CommandType = CommandType.StoredProcedure
                };
                cm.Connection = conn;
                string comando;

                if (registro == null)
                {
                    comando = "SP_CANCELAR_RESERVA";
                    
                    cm.Parameters.AddWithValue("@Cod", codReserva);
                }
                else
                {
                    comando = "SP_CANCELAR_RESERVA_MULTA";

                    cm.Parameters.AddWithValue("@Cod_Registro", registro.Codigo);
                    cm.Parameters.AddWithValue("@Cod_Reserva", codReserva);
                    cm.Parameters.AddWithValue("@Multa", registro.Valor);
                    cm.Parameters.AddWithValue("@Pagto", registro.Forma.ToString());
                    cm.Parameters.AddWithValue("@Data_Reserva", registro.DataPagto);
                    cm.Parameters.AddWithValue("@Ativo", registro.Ativo);
                }

                cm.CommandText = comando;
                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    reservaCancelada = true;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    reservaCancelada = false;
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return reservaCancelada;
        }

        public Reserva GetReservaByCod(Guid? cod)
        {
            Reserva reserva = null;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_RESERVA_COD";
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
                            reserva = new Reserva(cod: Guid.Parse(dr["Cod_Reserva"].ToString()), codCliente: Guid.Parse(dr["Cod_Cliente"].ToString()), cliente: null, codQuarto: Guid.Parse(dr["Cod_Quarto"].ToString()), quarto: null, acomp: Convert.ToInt32(dr["Num_Acomp"]), total: Convert.ToDouble(dr["Total"]), entrada: Convert.ToDateTime(dr["Entrada"]), saida: Convert.ToDateTime(dr["Saida"]), reserva: Convert.ToDateTime(dr["Reserva"]), status: (StatusReserva)Enum.Parse(typeof(StatusReserva), dr["Status"].ToString()), ativo: Convert.ToBoolean(dr["Ativo_Reserva"]));

                            cliente = _clienteRepository.GetClienteByCod(reserva.CodCliente);
                            quarto = _quartoRepository.GetQuartoByCod(reserva.CodQuarto);

                            reserva.AdicionarComplemento(cliente);
                            reserva.AdicionarComplemento(quarto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return reserva;
        }

        public IEnumerable<Reserva> GetReservas()
        {
            List<Reserva> reservas = new();

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_RESERVAS";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                Reserva reserva = null;
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
                            reserva = new Reserva(cod: Guid.Parse(dr["Cod_Reserva"].ToString()), codCliente: Guid.Parse(dr["Cod_Cliente"].ToString()), cliente: null, codQuarto: Guid.Parse(dr["Cod_Quarto"].ToString()), quarto: null, acomp: Convert.ToInt32(dr["Num_Acomp"]), total: Convert.ToDouble(dr["Total"]), entrada: Convert.ToDateTime(dr["Entrada"]), saida: Convert.ToDateTime(dr["Saida"]), reserva: Convert.ToDateTime(dr["Reserva"]), status: (StatusReserva)Enum.Parse(typeof(StatusReserva), dr["Status"].ToString()), ativo: Convert.ToBoolean(dr["Ativo_Reserva"]));

                            cliente = _clienteRepository.GetClienteByCod(reserva.CodCliente);
                            quarto = _quartoRepository.GetQuartoByCod(reserva.CodQuarto);

                            reserva.AdicionarComplemento(cliente);
                            reserva.AdicionarComplemento(quarto);

                            reservas.Add(reserva);
                        }
                    }   
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return reservas;
        }

        public IEnumerable<Reserva> GetReservasByStatus(string status)
        {
            List<Reserva> reservas = new();

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_RESERVAS_STATUS";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Status", status);

                Reserva reserva = null;
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
                            reserva = new Reserva(cod: Guid.Parse(dr["Cod_Reserva"].ToString()), codCliente: Guid.Parse(dr["Cod_Cliente"].ToString()), cliente: null, codQuarto: Guid.Parse(dr["Cod_Quarto"].ToString()), quarto: null, acomp: Convert.ToInt32(dr["Num_Acomp"]), total: Convert.ToDouble(dr["Total"]), entrada: Convert.ToDateTime(dr["Entrada"]), saida: Convert.ToDateTime(dr["Saida"]), reserva: Convert.ToDateTime(dr["Reserva"]), status: (StatusReserva)Enum.Parse(typeof(StatusReserva), dr["Status"].ToString()), ativo: Convert.ToBoolean(dr["Ativo_Reserva"]));

                            cliente = _clienteRepository.GetClienteByCod(reserva.CodCliente);
                            quarto = _quartoRepository.GetQuartoByCod(reserva.CodQuarto);

                            reserva.AdicionarComplemento(cliente);
                            reserva.AdicionarComplemento(quarto);

                            reservas.Add(reserva);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return reservas;
        }

        public IEnumerable<Reserva> GetReservasForCheckIn(string cpf)
        {
            List<Reserva> reservas = new();

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_RESERVA_CHECKIN";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cpf", cpf);

                Reserva reserva = null;
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
                            reserva = new Reserva(cod: Guid.Parse(dr["Cod_Reserva"].ToString()), codCliente: Guid.Parse(dr["Cod_Cliente"].ToString()), cliente: null, codQuarto: Guid.Parse(dr["Cod_Quarto"].ToString()), quarto: null, acomp: Convert.ToInt32(dr["Num_Acomp"]), total: Convert.ToDouble(dr["Total"]), entrada: Convert.ToDateTime(dr["Entrada"]), saida: Convert.ToDateTime(dr["Saida"]), reserva: Convert.ToDateTime(dr["Reserva"]), status: (StatusReserva)Enum.Parse(typeof(StatusReserva), dr["Status"].ToString()), ativo: Convert.ToBoolean(dr["Ativo_Reserva"]));

                            cliente = _clienteRepository.GetClienteByCod(reserva.CodCliente);
                            quarto = _quartoRepository.GetQuartoByCod(reserva.CodQuarto);

                            reserva.AdicionarComplemento(cliente);
                            reserva.AdicionarComplemento(quarto);

                            reservas.Add(reserva);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return reservas;
        }

        public bool SaveReserva(RegistroPagamento registro)
        {
            bool reservaInserida;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                SqlTransaction transaction;
                var coamndo = "SP_REALIZAR_RESERVA";
                
                SqlCommand cm = new(coamndo, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", registro.CodReserva);
                cm.Parameters.AddWithValue("@Cod_Cliente", registro.Reserva.CodCliente);
                cm.Parameters.AddWithValue("@Cod_Quarto", registro.Reserva.CodQuarto);
                cm.Parameters.AddWithValue("@Num_Acomp", registro.Reserva.NumAcompanhantes);
                cm.Parameters.AddWithValue("@Data_Entrada", registro.Reserva.DataEntrada.Date.ToUniversalTime());
                cm.Parameters.AddWithValue("@Data_Saida", registro.Reserva.DataSaida.Date.ToUniversalTime());
                cm.Parameters.AddWithValue("@Data_Reserva", registro.Reserva.DataReserva.Date.ToUniversalTime());
                cm.Parameters.AddWithValue("@Pagto", registro.Forma.ToString());
                cm.Parameters.AddWithValue("@Total_Diaria", registro.Valor);
                cm.Parameters.AddWithValue("@Status_Reserva", registro.Reserva.Status.ToString());
                cm.Parameters.AddWithValue("@Ativo", registro.Reserva.Ativo);

                conn.Open();
                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    reservaInserida = true;
                }
                catch
                {
                    transaction.Rollback();
                    reservaInserida = false;
                }
            }

            return reservaInserida;
        }
    }
}
