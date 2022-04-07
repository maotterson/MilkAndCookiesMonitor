using System.Net.NetworkInformation;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;

public class MongoContainerService : IContainerService
{
    public MongoContainerSettings ContainerSettings { get; init; } = null!;
    public MongoDatabaseService? CurrentDatabaseService { get; set; }
    private MongoClient _mongoClient;

    public MongoContainerService(IContainerSettings settings)
    {
        ContainerSettings = (MongoContainerSettings)settings;
        Connect();
    }
    IContainerSettings IContainerService.GetSettings() => ContainerSettings;

    public async Task<IList<string>> GetDatabases()
    {
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
        catch(Exception ex)
        {
            // todo
            Console.WriteLine(ex.Message);
        }

    }
    public void SetCurrentDBByName(string dbName)
    {
        var db = _mongoClient.GetDatabase(dbName);
        CurrentDatabaseService = new(db);
    }
    public void ResetDB()
    {
        CurrentDatabaseService = null;
    }

    public EContainerStatus GetStatus()
    {
        try
        {
            var isSuccess = _mongoClient.Cluster.Description.State == ClusterState.Connected;

            return isSuccess ? EContainerStatus.Reachable : throw new();
        }
        catch (Exception ex)
        {
            return EContainerStatus.Unreachable;
        }
    }
}
