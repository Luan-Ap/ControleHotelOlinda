using ControleHotel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Dominio.Interfaces.Repository
{
    public interface IEnderecoRepository
    {
        bool SaveEndereco(Endereco endereco);
        bool UpdateEndereco(Endereco endereco);
    }
}
