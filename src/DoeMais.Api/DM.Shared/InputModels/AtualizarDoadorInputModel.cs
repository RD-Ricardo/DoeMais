using DM.Domain.Enums;

namespace DM.Shared.InputModels
{
    public class AtualizarDoadorInputModel
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public Genero Genero { get; set; }
        public double Peso { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
    }
}
