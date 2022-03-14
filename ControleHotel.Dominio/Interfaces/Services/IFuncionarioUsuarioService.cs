using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Services
{
    public interface IFuncionarioUsuarioService
    {
        bool ValidarUsuario(FuncionarioUsuario usuario);
        bool SaveUpdateFuncionarioUsuario(FuncionarioUsuario func, bool alterarFunc = false);
        IEnumerable<FuncionarioUsuario> GetFuncionarioUsuario();
        FuncionarioUsuario GetFuncionarioUsuarioByCod(Guid? cod);
        FuncionarioUsuario GetFuncionarioUsuarioByLogin(string usuario, string senha);
    }
}
