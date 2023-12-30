using DM.Core.Messages;
using DM.Shared.ViewModels;
using FluentValidation;

namespace DM.Application.Queries.Doacao.DoacoesPorDoador
{
    public class DoacoesPorDoadorQuery : Query<IEnumerable<DoacaoViewModel>>
    {
        public DoacoesPorDoadorQuery(string doadorId)
        {
            DoadorId = Guid.Parse(doadorId);
        }
        public Guid DoadorId { get; private set; }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }


        private class DoacoesPorDoadorQueryValidator : AbstractValidator<DoacoesPorDoadorQuery> 
        {
            public DoacoesPorDoadorQueryValidator()
            {
                RuleFor(d => d.DoadorId)
                    .NotNull()
                    .NotEmpty();
            }
        }
    }
}
