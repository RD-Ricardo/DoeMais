namespace DM.Core.WebApi
{
    public class RequestResult<TDados>
    {
        public TDados? Dados { get; private set; }
        public bool Sucesso { get; private set; }
        public List<string>? MensagensErros { get; private set; }
        public RequestResult(bool sucesso, List<string> mensagemErro = null, TDados dados = default)
        {
            Dados = dados;
            Sucesso = sucesso;
            MensagensErros = mensagemErro;
        }
    }

}
