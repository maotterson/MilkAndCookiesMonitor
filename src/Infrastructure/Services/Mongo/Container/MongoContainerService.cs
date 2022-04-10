using System.Net.NetworkInformation;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;

public class MongoContainerService : IContainerService, IMongoContainerService
{
    public MongoContainerSettings ContainerSettings { get; init; } = null!;
    public IMongoDatabaseService? CurrentDatabaseService { get; set; }
    private MongoClient? _mongoClient;

    public MongoContainerService(IContainerSettings settings)
    {
        ContainerSettings = (MongoContainerSettings)settings;
        Connect();
    }
    IContainerSettings IContainerService.GetSettings() => ContainerSettings;
    public EContainerStatus GetStatus()
    {
        try
        {
            if (_mongoClient is null) throw new();
            var isSuccess = _mongoClient.Cluster.Description.State == ClusterState.Connected;

            return isSuccess ? EContainerStatus.Reachable : throw new("Container unreachable.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return EContainerStatus.Unreachable;
        }
    }
    public async Task<IList<string>> GetDatabasesAsync()
    {
        if (_mongoClient is null) throw new();
        var cursor = await _mongoClient.ListDatabaseNamesAsync();
        return cursor.ToList();
    }
    public void Connect()
    {
        try
        {
            var connectionString = ContainerSettings.ConnectionString is not null ? ContainerSettings.ConnectionString.Value : throw new();
            _mongoClient = new MongoClient(connectionString);
        }
        catch (Exception ex)
        {
            // todo
            Console.WriteLine(ex.Message);
        }

    }
    public void SetCurrentDBByName(string dbName)
    {
        if (_mongoClient is null) throw new();
        var db = _mongoClient.GetDatabase(dbName);
        CurrentDatabaseService = new MongoDatabaseService(db);
    }
    public void ResetDB()
    {
        CurrentDatabaseService = null;
    }
}
