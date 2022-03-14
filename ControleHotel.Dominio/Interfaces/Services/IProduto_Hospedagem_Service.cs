using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Services
{
    public interface IProduto_Hospedagem_Service
    {
        bool ValidarProdutoHospedagem(Produto_Hospedagem consumo);
        bool SaveConsumos(Produto_Hospedagem prodHosp);
        IEnumerable<Produto_Hospedagem> GetConsumosByHospedagem(Guid? cod);
    }
}
