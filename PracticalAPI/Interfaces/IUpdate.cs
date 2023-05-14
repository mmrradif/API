namespace PracticalAPI.Interfaces
{
    public interface IUpdate<T> where T : class
    {
        Task<bool> Update(T entity);
    }
    
}
