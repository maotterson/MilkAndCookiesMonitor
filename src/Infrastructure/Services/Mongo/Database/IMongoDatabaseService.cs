public interface IMongoDatabaseService
{
    public IMongoCollectionService? CurrentCollectionService { get; set; }
    public Task<List<string>> GetCollectionNamesAsync();
    public void SetCurrentCollectionServiceByName(string collectionName);
    public void ResetCollection();
}
