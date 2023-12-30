namespace DM.Core.DomainObjects.ValueObjects
{
    public record Endereco(string Logradouro, 
        string Cidade, 
        string Estado, 
        string Cep);
}
