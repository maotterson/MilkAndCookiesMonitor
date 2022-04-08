using MongoDB.Driver;

public class MongoCollectionService : IMongoCollectionService
{
    private IMongoCollection<dynamic> _collection;
    public MongoCollectionService(IMongoCollection<dynamic> collection)
    {
        _collection=collection;
    }

    public async Task<IList<dynamic>> GetAllItemsAsync()
    {
        var items = await _collection.Find(_ => true).ToListAsync();
        return items;
    }
}
