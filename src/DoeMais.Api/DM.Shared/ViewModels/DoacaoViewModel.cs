namespace DM.Shared.ViewModels
{
    public class DoacaoViewModel
    {
        public Guid DoadorId { get; set; }
        public string DaoadorNome { get; set; }
        public DateTime DataDoacao { get; set; }
        public double QuantidadeML { get; set; }
    }
}
