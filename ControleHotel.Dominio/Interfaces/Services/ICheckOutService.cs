using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Services
{
    public interface ICheckOutService
    {
        bool ValidarCheckOut(CheckOut checkOut);
        Hospedagem VerificarDataHospedagemCheckOut(Hospedagem hospedagems);
        bool RealizarCheckOut(CheckOut checkOut, RegistroPagamento registro = null);
    }
}
