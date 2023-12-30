using Newtonsoft.Json;

namespace DM.Shared.ViewModels
{
    public class EstoqueSangueItemViewModel
    {
        public EstoqueSangueItemViewModel(int qunatidadePessoa, double quantidadeMl)
        {
            QuantidadeDoadores = qunatidadePessoa;
            QuantidadeML = quantidadeMl;
        }

        [JsonProperty("QuantidadeDoadores")]
        public int QuantidadeDoadores { get; private set; }
        public double QuantidadeML { get; private set; }
    }
}
