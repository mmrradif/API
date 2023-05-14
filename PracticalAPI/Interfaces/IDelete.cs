namespace PracticalAPI.Interfaces
{
    public interface IDelete<T> where T : class
    {
        Task<bool> Delete(int id);
    }
}
