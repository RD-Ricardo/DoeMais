using DM.Core.DomainObjects;
using System;

namespace DM.Domain.Entities
{
    public class Doacao : Entity, IAggregateRoot
    {
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }
        public int DoadorId { get; private set; }
        public Doador Doador { get; set; }
        public Doacao(DateTime dataDoacao, int quantidadeML, int doadorId, Doador doador)
        {
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
            DoadorId = doadorId;
            Doador = doador;
        }

        public void Update(Doacao doacao) 
        {
            Data
        }
    }
}
