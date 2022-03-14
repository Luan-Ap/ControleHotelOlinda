using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Services
{
    public interface IRegistroPagamentoService
    {
        bool ValidarRegistro(RegistroPagamento registro);
        IEnumerable<RegistroPagamento> GetRegistrosPagamentos();
    }
}
