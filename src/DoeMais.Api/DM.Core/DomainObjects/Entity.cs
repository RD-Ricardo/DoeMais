using DM.Core.Messages;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace DM.Core.DomainObjects
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [DataMember]
        public Guid Id { get; set; }
        
        public DateTime DataCadastro { get; private set; }
        
        public DateTime DataAtualizado { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public void SetDataCadastro(DateTime dataCadastro)
        {
            DataCadastro = dataCadastro;
        }
        
        public void SetDataAtualizado(DateTime dataAtualizado)
        {
            DataAtualizado= dataAtualizado;
        }

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
