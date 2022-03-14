using FluentValidation.Results;
using System;

namespace ControleHotel.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public Guid Codigo { get; protected set; }
        public ValidationResult Validacao { get; protected set; }
        public bool Ativo { get; protected set; }
        public abstract bool Validar();
    }
}
