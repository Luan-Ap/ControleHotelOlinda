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
    public class HospedagemService : IHospedagemService
    {
        private readonly IHospedagemRepository _hospedagemRepository;

        public HospedagemService(IHospedagemRepository hospedagemRepository)
        {
            _hospedagemRepository = hospedagemRepository;
        }

        public Hospedagem GetHospedagemByCod(Guid? cod)
        {
            return _hospedagemRepository.GetHospedagemByCod(cod);
        }

        public Hospedagem GetHospedagemForCheckOut(string cpf)
        {
            return _hospedagemRepository.GetHospedagemForCheckOut(cpf);
        }

        public IEnumerable<Hospedagem> GetHospedagens()
        {
            return _hospedagemRepository.GetHospedagens();
        }

        public IEnumerable<Hospedagem> GetHospedagensByStatus(bool status)
        {
            return _hospedagemRepository.GetHospedagensByStatus(status);
        }

        public bool SavaHospedagem(Hospedagem hospedagem)
        {
            return _hospedagemRepository.SavaHospedagem(hospedagem);
        }

        public bool ValidarHospedagem(Hospedagem hospedagem)
        {
            var valido = hospedagem.Validar();

            return valido;
        }

        public bool VerificarConsumos(double consumo)
        {
            return Hospedagem.VerificarHaConsumos(consumo);
        }
    }
}
