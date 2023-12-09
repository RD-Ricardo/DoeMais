using DM.Core.DomainObjects;

namespace DM.Domain.Entities
{
    public class Doador : Entity, IAggregateRoot
    {
        public string NomeCompleto { get; set; }
        
        public Email Email { get; set; }
        
        public string Genero { get; set; }
        
        public double Peso { get; set; }
        
        public string TipoSanguineo { get; set; }
        
        public string FatorRh { get; set; }
        
        public DateTime DataNascimento { get; set; }
        
        public Doador()
        {
        }
    }
}
