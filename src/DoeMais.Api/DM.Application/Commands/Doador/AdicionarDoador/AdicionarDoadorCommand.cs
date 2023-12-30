using DM.Core.Messages;
using DM.Core.MessagesExceptions;
using DM.Domain.Enums;
using FluentValidation;

namespace DM.Application.Command.Doador.AdicionarDoador
{
    public class AdicionarDoadorCommand : Command<bool>
    {
        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public Genero Genero { get; private set; }
        public double Peso { get; private set; }
        public TipoSanguineo TipoSanguineo { get; private set; }
        public FatorRh FatorRh { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cep { get; private set; }
        public AdicionarDoadorCommand(string nomeCompleto,
            string email,
            double peso,
            int tipoSanguineo,
            int fatorRh,
            int genero,
            DateTime dataNascimento,
            string cep)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Genero = (Domain.Enums.Genero)genero;
            Peso = peso;
            TipoSanguineo = (Domain.Enums.TipoSanguineo)tipoSanguineo;
            FatorRh = (Domain.Enums.FatorRh)fatorRh;
            DataNascimento = dataNascimento;
            Cep = cep;
        }

        public override bool IsValid()
        {
            ValidationResultCommand = new AdicionarDoadorCommandValidator().Validate(this);
            return ValidationResultCommand.IsValid;
        }

        private class AdicionarDoadorCommandValidator : AbstractValidator<AdicionarDoadorCommand> 
        {
            public AdicionarDoadorCommandValidator()
            {
                RuleFor(d => d.Peso)
                    .NotNull()
                    .NotEmpty();

               // RuleFor(d => d.Peso)
                 //   .GreaterThan(50)
                   // .WithMessage(MessagesExceptions.PESO_INVALIDO);

                RuleFor(d => d.Email)
                    .EmailAddress();

                RuleFor(d => d.NomeCompleto)
                   .NotNull()
                   .NotEmpty()
                   .WithMessage(MessagesExceptions.NOME_OBRIGATORIO);

                RuleFor(d => d.Genero)
                  .NotNull();

                RuleFor(d => d.Cep)
                 .NotNull()
                 .NotEmpty();
            }
        } 
    }
}
