using MongoDB.Driver;

public class MongoDatabaseService
{
    private IMongoDatabase _database = null;

    public MongoDatabaseService(IMongoDatabase db)
    {
        _database = db;
    }

    public async Task<List<string>> DumpCollectionNames()
    {
        var collections = await _database.ListCollectionNamesAsync();
        var list = collections.ToList();
        return list;
    }
}
