public interface IMongoContainerService
{
    public void Connect();
    public Task<IList<string>> GetDatabasesAsync();
    public void SetCurrentDBByName(string dbName);
    public void ResetDB();
}
