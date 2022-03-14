using ControleHotel.Dominio.Entidades;
using ControleHotel.Dominio.Interfaces.Repository;
using ControleHotel.Dominio.Interfaces.Services;
using ControleHotel.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Services.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public bool CancelarReserva(Guid? codReserva, RegistroPagamento registro = null)
        {
            var reservaCancelada = _reservaRepository.CancelarReserva(codReserva, registro);

            return reservaCancelada;
        }

        public Reserva GetReservaByCod(Guid? cod)
        {
            return _reservaRepository.GetReservaByCod(cod);
        }

        public IEnumerable<Reserva> GetReservas(string status = "")
        {
            if (string.IsNullOrEmpty(status))
            {
                return _reservaRepository.GetReservas();
            }
            else
            {
                return _reservaRepository.GetReservasByStatus(status);
            }
        }

        public IEnumerable<Reserva> GetReservasForCheckIn(string cpf)
        {
            return _reservaRepository.GetReservasForCheckIn(cpf);
        }

        public bool SaveReserva(RegistroPagamento registro)
        {
            return _reservaRepository.SaveReserva(registro);
        }

        public bool ValidarReserva(Reserva reserva)
        {
            var valida = reserva.Validar();

            return valida;
        }

        public double VerificarMultaCancelamento(Reserva reserva)
        {
            if (Reserva.VerificarHaMultaParaCancelamento(reserva.DataEntrada))
            {
                double multa = reserva.TotalDiaria * 0.10;
                return multa;
            }
            else
            {
                return 0;
            }
        }
    }
}
