using MongoDB.Bson;
using Newtonsoft.Json.Linq;

public interface IMongoCollectionService
{
    public Task<JArray> GetAllItemsAsJSONAsync();
}
