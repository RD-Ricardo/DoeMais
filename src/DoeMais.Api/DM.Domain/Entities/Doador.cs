using DM.Core.DomainObjects;
using DM.Core.DomainObjects.ValueObjects;
using DM.Domain.Enums;

namespace DM.Domain.Entities
{
    public class Doador : Entity, IAggregateRoot
    {
        public string NomeCompleto { get; set; }
        public string Email { get; private set; }
        public double Peso { get; private set; }
        public Genero Genero { get; private set; }
        public TipoSanguineo TipoSanguineo { get; private set; }
        public FatorRh FatorRh { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Doador(string nomeCompleto, 
            string email, 
            double peso, 
            Genero genero, 
            TipoSanguineo tipoSanguineo, 
            FatorRh fatorRh, 
            DateTime dataNascimento, 
            Endereco endereco)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Genero = genero;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            DataNascimento = dataNascimento;
            Endereco = endereco;
        }

        public void Update(string nomeCompleto, string email, Genero genero, double peso, DateTime dataNascimento, Endereco endereco)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Genero = genero;
            Peso = peso;
            DataNascimento = dataNascimento;
            Endereco = endereco;
        }

        public bool MaiorDeIdade()
        {
            var idade =  DateTime.Now.Year - DataNascimento.Year;
            return idade >= 18;
        }

        // EF 
        protected Doador() { }
        public Endereco Endereco { get; private set; }
        public ICollection<Doacao> Doacoes { get; set; }
    }
}
