using MongoDB.Driver;

public class MongoDatabaseService : IMongoDatabaseService
{
    private IMongoDatabase _database = null!;
    private IMongoCollectionService? _service = null;

    public MongoDatabaseService(IMongoDatabase db)
    {
        _database = db;
    }
    public async Task<List<string>> GetCollectionNamesAsync()
    {
        var collections = await _database.ListCollectionNamesAsync();
        var list = collections.ToList();
        return list;
    }
    public void ResetCollection()
    {
        _service = null;
    }
    public void SetCurrentCollectionServiceByName(string collectionName)
    {
        var collection = _database.GetCollection<string>(collectionName);
        _service = new MongoDatabaseService(collection);
    }

}
