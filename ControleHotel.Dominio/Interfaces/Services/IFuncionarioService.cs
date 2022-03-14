using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Services
{
    public interface IFuncionarioService
    {
        bool ValidarFuncionario(Funcionario func);
        bool SaveUpdateFuncionario(Funcionario func, bool alterarFunc = false);
        IEnumerable<Funcionario> GetFuncionarios(string nome = "", string sobrenome = "");
        Funcionario GetFuncionarioByCpf(string cpf);
        Funcionario GetFuncionarioByCod(Guid? cod);
        bool DesativarFuncionario(Guid? cod);
    }
}
