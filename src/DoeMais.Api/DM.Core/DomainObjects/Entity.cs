using DM.Core.Messages;
using System.Reflection.PortableExecutable;

namespace DM.Core.DomainObjects
{
    public abstract class Entity
    {
        public int Id { get; private set; }
        
        public DateTime DataCadastro { get; private set; }
        
        public DateTime DataAtualizado { get; private set; }

        public void SetDataAtualizado(DateTime dataAtualizado)
        {
            DataAtualizado= dataAtualizado;
        }

        public Entity() { }

        private List<Event> _eventos;
        
        public IReadOnlyCollection<Event> Eventos =>
            _eventos?.AsReadOnly();

        public void AdicionarEvento(Event @event)
        {
            _eventos = _eventos ??  new List<Event>();
            _eventos.Add(@event);
        }

        public void RemoverEvento(Event @event)
        {
            _eventos?.Remove(@event);
        }

        public void LimparEventos()
        {
            _eventos?.Clear();
        }
    }
}
