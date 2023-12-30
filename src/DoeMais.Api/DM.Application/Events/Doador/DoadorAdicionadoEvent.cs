using DM.Core.DomainObjects.ValueObjects;
using DM.Core.Messages;
using DM.Domain.Enums;

namespace DM.Application.Events.Doador
{
    public class DoadorAdicionadoEvent : Event
    {
        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public Genero Genero { get; private set; }
        public double Peso { get; private set; }
        public TipoSanguineo TipoSanguineo { get; private set; }
        public FatorRh FatorRh { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DoadorAdicionadoEvent(string nomeCompleto, 
            string email, 
            Genero genero, 
            double peso, 
            TipoSanguineo tipoSanguineo, 
            FatorRh fatorRh, 
            DateTime dataNascimento)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Genero = genero;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            DataNascimento = dataNascimento;
        }

        public Domain.Entities.Doador ToEntity()
        {
            return new Domain.Entities.Doador(NomeCompleto, 
                Email, 
                Peso, 
                Genero, 
                TipoSanguineo, 
                FatorRh, 
                DataNascimento, 
                new Endereco("teste", "teste", "teste", "testee"));
        }
    }
}
