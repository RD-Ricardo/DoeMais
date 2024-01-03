namespace DM.Application.Services
{
    public interface IEmailService
    {
        Task<bool> EnviarEmail(string emailDestinatario, string caminhoAnexo = null);
    }
}
