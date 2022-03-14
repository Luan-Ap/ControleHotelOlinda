using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Services
{
    public interface IClienteService
    {
        bool ValidarCliente(Cliente cliente);
        bool SaveUpdateCliente(Cliente cliente, bool alterarClinte = false);
        IEnumerable<Cliente> GetClientes(string nome = "", string sobrenome = "");
        Cliente GetClienteByCpf(string cpf);
        Cliente GetClienteByCod(Guid? cod);
        Cliente GetClienteByLogin(string usuario, string senha);
        bool DesativarCliente(Guid? cod);
    }
}
