using DM.Core.Messages;
using DM.Shared.ViewModels;

namespace DM.Application.Queries.Doacao.ListarTodasDoacoes
{
    public class ListarTodasDoacoesQuery : Query<IEnumerable<DoacaoViewModel>>
    {
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
