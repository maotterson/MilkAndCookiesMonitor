public interface IMongoCollectionService
{
    public Task<IList<dynamic>> GetAllItemsAsync();
}
