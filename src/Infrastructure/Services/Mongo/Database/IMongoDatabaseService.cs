public interface IMongoDatabaseService
{
    public Task<List<string>> GetCollectionNamesAsync();
    public void SetCurrentCollectionServiceByName(string collectionName);
    public void ResetCollection();
}
