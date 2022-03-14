using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Services
{
    public interface ICheckInService
    {
        bool ValidarCheckIn(CheckIn checkIn);
        Reserva VerificarDataReservaCheckIn(List<Reserva> reserva);
        bool RealizarCheckIn(CheckIn checkIn);

    }
}
