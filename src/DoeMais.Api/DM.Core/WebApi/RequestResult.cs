namespace DM.Core.WebApi
{
    public class RequestResult<TDados>
    {
        public TDados? Dados { get; private set; }
        public bool Sucesso { get; private set; }
        public string? MensagemErro { get; private set; }
        public RequestResult(bool sucesso, TDados? dados, string? mensagemErro)
        {
            Dados = dados;
            Sucesso = sucesso;
            MensagemErro = mensagemErro;
        }
    }

}
