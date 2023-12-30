using DM.Core.Messages;
using DM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Application.Events.EstoqueSangue
{
    public class EstoqueSangueAtualizadoEvent : Event
    {
        public FatorRh FatorRh { get; private set; }
        public TipoSanguineo TipoSanguineo { get; private set; }
        public double QuantidadeMl { get; private set; }
        public EstoqueSangueAtualizadoEvent(FatorRh fatorRh, TipoSanguineo tipoSanguineo, double quantidadeMl)
        {
            FatorRh = fatorRh;
            TipoSanguineo = tipoSanguineo;
            QuantidadeMl = quantidadeMl;
        }
    }
}
