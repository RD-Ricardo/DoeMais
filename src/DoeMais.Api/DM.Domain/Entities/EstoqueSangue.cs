using DM.Core.DomainObjects;
using DM.Domain.Enums;

namespace DM.Domain.Entities
{
    public class EstoqueSangue : Entity, IAggregateRoot
    {
        public TipoSanguineo TipoSanguineo { get; private set; }
        public FatorRh FatorRh {  get; private set; }
        public double QuantidadeML {  get; private set; }
        public EstoqueSangue(TipoSanguineo tipoSanguineo, FatorRh fatorRh, double quantidadeML)
        {
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            QuantidadeML = quantidadeML;
        }
        protected EstoqueSangue() { }

        public void AdicionarQuantidadeMl(double quantiadeMl)
        {
            QuantidadeML += quantiadeMl;
        }
    }
}
