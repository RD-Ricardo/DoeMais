namespace DM.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
