using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Repository
{
    public interface IFuncionarioRepository
    {
        bool SaveFuncionario(Funcionario func);
        bool UpdateFuncionario(Funcionario func);
        IEnumerable<Funcionario> GetFuncionarios();
        IEnumerable<Funcionario> GetFuncionarioByName(string nome, string sobrenome);
        Funcionario GetFuncionarioByCpf(string cpf);
        Funcionario GetFuncionarioByCod(Guid? cod);
        bool DesativarFuncionario(Guid? cod);
    }
}
