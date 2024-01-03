using DM.Core.Messages;
using DM.Domain.Enums;

namespace DM.Application.Events.EstoqueSangue
{
    public class EstoqueSangueAtualizadoEvent : Event
    {
        public string NomeDoador { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public FatorRh FatorRh { get; private set; }
        public TipoSanguineo TipoSanguineo { get; private set; }
        public double QuantidadeMl { get; private set; }
        public EstoqueSangueAtualizadoEvent(FatorRh fatorRh, TipoSanguineo tipoSanguineo, double quantidadeMl, string nomeDoador)
        {
            FatorRh = fatorRh;
            TipoSanguineo = tipoSanguineo;
            QuantidadeMl = quantidadeMl;
            NomeDoador = nomeDoador;
            DataDoacao = DateTime.Now;
        }
    }
}
