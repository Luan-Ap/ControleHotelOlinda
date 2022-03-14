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
    public class Produto_Hospedagem_Service : IProduto_Hospedagem_Service
    {
        private readonly IProduto_Hospedagem_Repository _prodHospRepo;

        public Produto_Hospedagem_Service(IProduto_Hospedagem_Repository prodHospRepo)
        {
            _prodHospRepo = prodHospRepo;
        }

        public IEnumerable<Produto_Hospedagem> GetConsumosByHospedagem(Guid? cod)
        {
            return _prodHospRepo.GetConsumosByHospedagem(cod);
        }

        public bool SaveConsumos(Produto_Hospedagem prodHosp)
        {
            return _prodHospRepo.SaveConsumos(prodHosp);
        }

        public bool ValidarProdutoHospedagem(Produto_Hospedagem consumo)
        {
            var valido = consumo.Validar();

            return valido;
        }
    }
}
