namespace PracticalAPI.Interfaces
{
    public interface ISaveChanges:IDisposable
    {
        Task Complete();
    }
}
