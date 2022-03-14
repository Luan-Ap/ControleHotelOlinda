using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Services
{
    public interface IProdutoService
    {
        bool ValidarProduto(Produto produto);
        bool SaveUpadateProduto(Produto produto, bool alterarProduto  = false);
        IEnumerable<Produto> GetProdutos(string tipo = "");
        Produto GetProdutoByCod(Guid? cod);
        bool DesativarProduto(Guid? cod);
    }
}
