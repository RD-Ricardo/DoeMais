using DM.Core.Messages;
using DM.Shared.ViewModels;

namespace DM.Application.Queries.Doador.ObterDoadorPorId
{
    public class ObterDoadorPorIdQuery : Query<DoadorPorIdViewModel>
    {
        public ObterDoadorPorIdQuery(string doadorId)
        {
            DoadorId = Guid.Parse(doadorId);
        }

        public Guid DoadorId { get; private set; }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
