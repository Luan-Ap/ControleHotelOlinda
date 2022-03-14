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
    public class CheckInService : ICheckInService
    {
        private readonly ICheckInRepository _checkInRepository;

        public CheckInService(ICheckInRepository checkInRepository)
        {
            _checkInRepository = checkInRepository;
        }

        public bool RealizarCheckIn(CheckIn checkIn)
        {
            var checkInFeito = _checkInRepository.SaveCheckIn(checkIn);

            return checkInFeito;
        }

        public bool ValidarCheckIn(CheckIn checkIn)
        {
            var valido = checkIn.Validar();

            return valido;
        }

        public Reserva VerificarDataReservaCheckIn(List<Reserva> reserva)
        {
            foreach (var res in reserva)
            {
                if (CheckIn.VerificarDataEntradaReservaValida(res.DataEntrada))
                {
                    return res;
                }
            }

            return null;
        }
    }
}
