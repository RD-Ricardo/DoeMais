namespace DM.Shared
{
    public class RequestResult<TDados>
    {
        public TDados Dados { get; set; }
        public bool Sucesso { get; set; }
        public List<string> MensagensErros { get; set; }
    }

}
