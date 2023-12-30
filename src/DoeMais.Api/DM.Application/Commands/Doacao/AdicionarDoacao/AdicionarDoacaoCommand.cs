using DM.Core.Messages;
using FluentValidation;
using MediatR;

namespace DM.Application.Commands.Doacao.AdicionarDoacao
{
    public class AdicionarDoacaoCommand : Command<Unit>
    {
        public Guid DoadorId { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public double QuantidadeML { get; private set; }
        public AdicionarDoacaoCommand(double quantidadeMl, string doadorId)
        {
            QuantidadeML = quantidadeMl;
            DoadorId = Guid.Parse(doadorId);
            DataDoacao = DateTime.UtcNow;
        }

        public override bool IsValid()
        {
            ValidationResultCommand = new AdicionarDoacaoCommandValidator().Validate(this);
            return ValidationResultCommand.IsValid; 
        }

        private class AdicionarDoacaoCommandValidator : AbstractValidator<AdicionarDoacaoCommand> 
        {
            public AdicionarDoacaoCommandValidator()
            {
                RuleFor(x => x.QuantidadeML)
                    .GreaterThan(420)
                    .LessThan(470);
                
                RuleFor(d => d.DoadorId)
                    .NotNull()
                    .NotEmpty();
            }
        }
    }
}
