using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        bool SaveProduto(Produto produto);
        bool UpdateProduto(Produto produto);
        IEnumerable<Produto> GetProdutos();
        IEnumerable<Produto> GetProdutosByTipo(string tipo);
        Produto GetProdutoByCod(Guid? cod);
        bool DesativarProduto(Guid? cod);
    }
}
