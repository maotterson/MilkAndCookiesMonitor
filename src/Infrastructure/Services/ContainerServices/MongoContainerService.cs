using MongoDB.Driver;

public class MongoContainerService : IContainerService
{
    public MongoContainerSettings ContainerSettings { get; init; } = null!;
    public MongoClient MongoClient { get; init; } = null!;

    public MongoContainerService(IContainerSettings settings)
    {
        ContainerSettings = (MongoContainerSettings)settings;

        var connectionString = ContainerSettings.ConnectionString is not null ? ContainerSettings.ConnectionString.Value : throw new();
        MongoClient = new MongoClient(connectionString);
        GetDatabases();
    }
    IContainerSettings IContainerService.GetSettings() => ContainerSettings;

    public async Task GetDatabases()
    {
        var databases = await MongoClient.ListDatabaseNamesAsync();
    }
}
