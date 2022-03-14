using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Services
{
    public interface IReservaService
    {
        bool ValidarReserva(Reserva reserva);
        double VerificarMultaCancelamento(Reserva reserva);
        bool SaveReserva(RegistroPagamento registro);
        IEnumerable<Reserva> GetReservas(string status = "");
        Reserva GetReservaByCod(Guid? cod);
        IEnumerable<Reserva> GetReservasForCheckIn(string cpf);
        bool CancelarReserva(Guid? codReserva, RegistroPagamento registro = null);
    }
}
