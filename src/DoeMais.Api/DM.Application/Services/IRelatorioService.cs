namespace DM.Application.Services
{
    public interface IRelatorioService
    {
        Task<bool> GerarRelatorioEstoqueSangue(string email);
    }
}
