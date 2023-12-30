using Newtonsoft.Json;
using DM.Shared.Enums;

namespace DM.Shared.InputModels
{
    public class DoadorInputModel
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public int Genero { get; set; }
        public double Peso { get; set; }
        public int TipoSanguineo { get; set; }
        public int FatorRh { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
    }
}
