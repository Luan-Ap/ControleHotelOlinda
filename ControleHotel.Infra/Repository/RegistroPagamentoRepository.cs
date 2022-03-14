using ControleHotel.Dominio.Entidades;
using ControleHotel.Dominio.Interfaces.Repository;
using ControleHotel.Infra.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Infra.Repository
{
    public class RegistroPagamentoRepository : IRegistroPagamentoRepository
    {
        private readonly IHospedagemRepository _hospedagemRepository;
        private readonly IReservaRepository _reservaRepository;

        public RegistroPagamentoRepository()
        {
            _hospedagemRepository = new HospedagemRepository();
            _reservaRepository = new ReservaRepository();
        }

        public IEnumerable<RegistroPagamento> GetRegistrosPagamentos()
        {
            List<RegistroPagamento> registros = new();

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_LISTAR_REGISTROS_PAGAMENTO";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                RegistroPagamento registro = null;
                Hospedagem hospedagem = null;
                Reserva reserva = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            registro = new RegistroPagamento(cod: Guid.Parse(dr["Cod_Registro"].ToString()), codReserva: dr["Cod_Hospedagem"] == null ? null : Guid.Parse(dr["Cod_Hospedagem"].ToString()), reserva: null, codHosp: dr["Cod_Reserva"] == null ? null : Guid.Parse(dr["Cod_Reserva"].ToString()), hosp: null, pagto: (FormaPagto)Enum.Parse(typeof(FormaPagto), dr["Forma_Pagto"].ToString()), valor: Convert.ToDouble(dr["Valor"]), dataPagto: Convert.ToDateTime(dr["Data_Pagto"]), ativo: Convert.ToBoolean(dr["Ativo_Registro"]));

                            if(registro.CodReserva == null)
                            {
                                hospedagem = _hospedagemRepository.GetHospedagemByCod(registro.CodHospedagem);
                                registro.AdicionarComplemento(hospedagem);
                            }
                            else
                            {
                                reserva = _reservaRepository.GetReservaByCod(registro.CodReserva);
                                registro.AdicionarComplemento(reserva);
                            }

                            registros.Add(registro);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return registros;
        }
    }
}
