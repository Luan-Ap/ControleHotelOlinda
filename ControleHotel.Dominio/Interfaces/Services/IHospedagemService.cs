using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Services
{
    public interface IHospedagemService
    {
        bool ValidarHospedagem(Hospedagem hospedagem);
        bool VerificarConsumos(double consumo);
        bool SavaHospedagem(Hospedagem hospedagem);
        IEnumerable<Hospedagem> GetHospedagens();
        IEnumerable<Hospedagem> GetHospedagensByStatus(bool status);
        Hospedagem GetHospedagemByCod(Guid? cod);
        Hospedagem GetHospedagemForCheckOut(string cpf);
    }
}
