using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Entidades.Service
{
    public interface IComplementoEntidades<T> where T : class
    {
        void AdicionarComplemento(T obj);
    }
}
