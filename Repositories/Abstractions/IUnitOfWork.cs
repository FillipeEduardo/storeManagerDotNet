namespace storeManagerDotNet.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
    }
}
