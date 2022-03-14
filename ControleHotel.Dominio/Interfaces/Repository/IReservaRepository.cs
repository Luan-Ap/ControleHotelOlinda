using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Repository
{
    public interface IReservaRepository
    {
        bool SaveReserva(RegistroPagamento registro);
        IEnumerable<Reserva> GetReservas();
        IEnumerable<Reserva> GetReservasByStatus(string status);
        Reserva GetReservaByCod(Guid? cod);
        IEnumerable<Reserva> GetReservasForCheckIn(string cpf);
        bool CancelarReserva(Guid? codReserva, RegistroPagamento registro = null);
    }
}
