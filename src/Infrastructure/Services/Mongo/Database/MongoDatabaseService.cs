using MongoDB.Bson;
using MongoDB.Driver;

public class MongoDatabaseService : IMongoDatabaseService
{
    private IMongoDatabase _database = null!;
    public IMongoCollectionService? CurrentCollectionService { get; set; }  

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
        CurrentCollectionService = null;
    }
    public void SetCurrentCollectionServiceByName(string collectionName)
    {
        var collection = _database.GetCollection<BsonDocument>(collectionName);
        CurrentCollectionService = new MongoCollectionService(collection);
    }

}
