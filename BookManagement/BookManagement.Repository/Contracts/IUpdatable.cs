namespace BookManagement.Repository.Contracts
{
    public interface IUpdatable<T> where T : class
    {
        Task Update(T entity);
    }
}
