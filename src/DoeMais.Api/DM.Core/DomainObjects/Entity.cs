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

        private readonly List<Event> _eventos = new();
        
        public IReadOnlyCollection<Event> Eventos =>
            _eventos;

        public IReadOnlyCollection<Event> GetEventos() =>
           _eventos.ToList();

        public void AdicionarEvento(Event @event)
        {
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
