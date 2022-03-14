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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public bool DesativarProduto(Guid? cod)
        {
            var prodDesativado = _produtoRepository.DesativarProduto(cod);

            return prodDesativado;
        }

        public Produto GetProdutoByCod(Guid? cod)
        {
            return _produtoRepository.GetProdutoByCod(cod);
        }

        public IEnumerable<Produto> GetProdutos(string tipo = "")
        {
            if (string.IsNullOrEmpty(tipo))
            {
                return _produtoRepository.GetProdutos();
            }
            else
            {
                return _produtoRepository.GetProdutosByTipo(tipo);
            }
        }

        public bool SaveUpadateProduto(Produto produto, bool alterarProduto = false)
        {
            if (alterarProduto == false)
            {
                return _produtoRepository.SaveProduto(produto);
            }
            else
            {
                return _produtoRepository.UpdateProduto(produto);
            }
        }

        public bool ValidarProduto(Produto produto)
        {
            var valido = produto.Validar();

            return valido;
        }
    }
}
