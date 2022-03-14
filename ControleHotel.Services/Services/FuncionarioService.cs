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
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public bool DesativarFuncionario(Guid? cod)
        {
            var funcDesativado = _funcionarioRepository.DesativarFuncionario(cod);

            return funcDesativado;
        }

        public Funcionario GetFuncionarioByCod(Guid? cod)
        {
            return _funcionarioRepository.GetFuncionarioByCod(cod);
        }

        public Funcionario GetFuncionarioByCpf(string cpf)
        {
            return _funcionarioRepository.GetFuncionarioByCpf(cpf);
        }

        public IEnumerable<Funcionario> GetFuncionarios(string nome = "", string sobrenome = "")
        {
            if (string.IsNullOrEmpty(nome) && string.IsNullOrEmpty(sobrenome))
            {
                return _funcionarioRepository.GetFuncionarios();
            }
            else
            {
                return _funcionarioRepository.GetFuncionarioByName(nome, sobrenome);
            }
        }

        public bool SaveUpdateFuncionario(Funcionario func, bool alterarFunc = false)
        {
            if (alterarFunc == false)
            {
                return _funcionarioRepository.SaveFuncionario(func);
            }
            else
            {
                return _funcionarioRepository.UpdateFuncionario(func);
            }
        }

        public bool ValidarFuncionario(Funcionario func)
        {
            var valido = func.Validar();

            return valido;
        }
    }
}
