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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool DesativarCliente(Guid? cod)
        {
            var clienteDesativado = _clienteRepository.DesativarCliente(cod);

            return clienteDesativado;
        }

        public Cliente GetClienteByCod(Guid? cod)
        {
            return _clienteRepository.GetClienteByCod(cod);
        }

        public Cliente GetClienteByCpf(string cpf)
        {
            return _clienteRepository.GetClienteByCpf(cpf);
        }

        public Cliente GetClienteByLogin(string usuario, string senha)
        {
            return _clienteRepository.GetClienteByLogin(usuario, senha);
        }

        public IEnumerable<Cliente> GetClientes(string nome = "", string sobrenome = "")
        {
            if (string.IsNullOrEmpty(nome) && string.IsNullOrEmpty(sobrenome))
            {
                return _clienteRepository.GetClientes();
            }
            else
            {
                return _clienteRepository.GetClienteByName(nome, sobrenome);
            }
        }

        public bool SaveUpdateCliente(Cliente cliente, bool alterarClinte = false)
        {
            if (alterarClinte == false)
            {
                return _clienteRepository.SaveCliente(cliente);
            }
            else
            {
                return _clienteRepository.UpdateCliente(cliente);
            }
        }

        public bool ValidarCliente(Cliente cliente)
        {
            var valido = cliente.Validar();

            return valido;
        }
    }
}
