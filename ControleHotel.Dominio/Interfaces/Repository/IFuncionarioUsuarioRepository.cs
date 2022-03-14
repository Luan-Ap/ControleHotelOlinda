using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Repository
{
    public interface IFuncionarioUsuarioRepository
    {
        bool SaveFuncionarioUsuario(FuncionarioUsuario func);
        bool UpdateFuncionarioUsuario(FuncionarioUsuario func);
        IEnumerable<FuncionarioUsuario> GetFuncionarioUsuario();
        FuncionarioUsuario GetFuncionarioUsuarioByCod(Guid? cod);
        FuncionarioUsuario GetFuncionarioUsuarioByLogin(string usuario, string senha);
    }
}
