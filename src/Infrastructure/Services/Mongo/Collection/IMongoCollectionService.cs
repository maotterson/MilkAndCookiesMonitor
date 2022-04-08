public interface IMongoCollectionService
{
    public Task<IList<dynamic>> GetAllItems();
}
