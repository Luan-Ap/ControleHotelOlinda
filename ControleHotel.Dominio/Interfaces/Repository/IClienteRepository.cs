using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Repository
{
    public interface IClienteRepository
    {
        bool SaveCliente(Cliente cliente);
        bool UpdateCliente(Cliente cliente);
        IEnumerable<Cliente> GetClientes();
        IEnumerable<Cliente> GetClienteByName(string nome, string sobrenome);
        Cliente GetClienteByCpf(string cpf);
        Cliente GetClienteByCod(Guid? cod);
        Cliente GetClienteByLogin(string usuario, string senha);
        bool DesativarCliente(Guid? cod);
    }
}
