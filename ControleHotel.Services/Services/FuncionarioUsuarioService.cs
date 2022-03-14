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
    public class FuncionarioUsuarioService : IFuncionarioUsuarioService
    {
        private readonly IFuncionarioUsuarioRepository _funcionarioUsuarioRepository;

        public FuncionarioUsuarioService(IFuncionarioUsuarioRepository funcionarioUsuarioRepository)
        {
            _funcionarioUsuarioRepository = funcionarioUsuarioRepository;
        }

        public IEnumerable<FuncionarioUsuario> GetFuncionarioUsuario()
        {
            return _funcionarioUsuarioRepository.GetFuncionarioUsuario();
        }

        public FuncionarioUsuario GetFuncionarioUsuarioByCod(Guid? cod)
        {
            return _funcionarioUsuarioRepository.GetFuncionarioUsuarioByCod(cod);
        }

        public FuncionarioUsuario GetFuncionarioUsuarioByLogin(string usuario, string senha)
        {
            return _funcionarioUsuarioRepository.GetFuncionarioUsuarioByLogin(usuario, senha);
        }

        public bool SaveUpdateFuncionarioUsuario(FuncionarioUsuario func, bool alterarFunc = false)
        {
            if (alterarFunc == false)
            {
                return _funcionarioUsuarioRepository.SaveFuncionarioUsuario(func);
            }
            else
            {
                return _funcionarioUsuarioRepository.UpdateFuncionarioUsuario(func);
            }
        }

        public bool ValidarUsuario(FuncionarioUsuario usuario)
        {
            var valido = usuario.Validar();

            return valido;
        }
    }
}
