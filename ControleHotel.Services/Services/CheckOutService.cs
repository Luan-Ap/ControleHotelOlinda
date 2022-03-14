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
    public class CheckOutService : ICheckOutService
    {
        private readonly ICheckOutRepository _checkOutRepository;

        public CheckOutService(ICheckOutRepository checkOutRepository)
        {
            _checkOutRepository = checkOutRepository;
        }

        public bool RealizarCheckOut(CheckOut checkIn, RegistroPagamento registro = null)
        {
            var checkOutFeito = _checkOutRepository.SaveCheckOut(checkIn, registro);

            return checkOutFeito;
        }

        public bool ValidarCheckOut(CheckOut checkOut)
        {
            var valido = checkOut.Validar();

            return valido;
        }

        public Hospedagem VerificarDataHospedagemCheckOut(Hospedagem hospedagems)
        {
            if (CheckOut.VerificarDataSaidaHospedagemValida(hospedagems.DataSaida))
            {
                return hospedagems;
            }

            return null;
        }
    }
}
