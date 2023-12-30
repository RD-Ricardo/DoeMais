using DM.Core.Messages;
using DM.Shared.ViewModels;

namespace DM.Application.Queries.Doador.ListarTodosDoadores
{
    public class ListarTodosDoadoresQuery : Query<IEnumerable<DoadorViewModel>>
    {
        public ListarTodosDoadoresQuery()
        {
            
        }
        public override bool IsValid()
        {
            return true;
        }
    }
}
