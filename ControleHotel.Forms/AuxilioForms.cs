using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Forms
{
    public class AuxilioForms
    {
        public static string ListarErrosPreenchimento<Entidade>(Entidade entidade) where Entidade : EntidadeBase
        {
            string erros = "";

            foreach (var erro in entidade.Validacao.Errors)
            {
                erros += $"{erro}\n";
            }

            return erros;
        }
    }
}
