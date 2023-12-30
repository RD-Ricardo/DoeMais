using DM.Core.DomainObjects;

namespace DM.Domain.Entities
{
    public class Doacao : Entity, IAggregateRoot
    {
        public DateTime DataDoacao { get; private set; }
        public double QuantidadeML { get; private set; }
        public Doacao(DateTime dataDoacao, double quantidadeML, Guid doadorId)
        {
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
            DoadorId = doadorId;
        }

        // EF
        protected Doacao() {}
        public Guid DoadorId { get; private set; }
        public virtual Doador Doador { get; private set; }

    }
}
