
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class MongoCollectionService : IMongoCollectionService
{
    private IMongoCollection<BsonDocument> _collection;
    public MongoCollectionService(IMongoCollection<BsonDocument> collection)
    {
        _collection=collection;
    }

    public async Task<JArray> GetAllItemsAsJSONAsync()
    {
        var itemsBson = await _collection.Find(_ => true).ToListAsync();
        var settings = new JsonWriterSettings
        {
            OutputMode = JsonOutputMode.Strict
        };
        var items = itemsBson.ConvertAll(BsonTypeMapper.MapToDotNetValue);
        var json = items.ToJson(settings);
        var array = JArray.Parse(json);

        return array;
    }

}
