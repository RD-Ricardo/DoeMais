using DM.Application.Command.Doador.AdicionarDoador;
using DM.Core.Messages;
using DM.Core.MessagesExceptions;
using DM.Domain.Enums;
using FluentValidation;
using MediatR;

namespace DM.Application.Command.Doador.AtualizarDoador
{
    public class AtualizarDoadorCommand : Command<Unit>
    {
        public Guid Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public Genero Genero { get; private set; }
        public double Peso { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cep { get; private set; }
        public AtualizarDoadorCommand(string id, string nomeCompleto, string email, Genero genero, double peso, DateTime dataNascimento, string cep)
        {
            Id = Guid.Parse(id);
            NomeCompleto = nomeCompleto;
            Email = email;
            Genero = genero;
            Peso = peso;
            DataNascimento = dataNascimento;
            Cep = cep;
        }
        public override bool IsValid()
        {
            ValidationResultCommand = new AtualizarDoadorCommandValidator().Validate(this);
            return ValidationResultCommand.IsValid;
        }


        private class AtualizarDoadorCommandValidator : AbstractValidator<AtualizarDoadorCommand>
        {
            public AtualizarDoadorCommandValidator()
            {
                RuleFor(d => d.Peso)
                    .NotNull()
                    .NotEmpty();

                RuleFor(d => d.Peso)
                    .GreaterThan(50)
                    .WithMessage(MessagesExceptions.PESO_INVALIDO);

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
