﻿using MongoDB.Driver;

public class MongoContainerService : IContainerService
{
    public MongoContainerSettings ContainerSettings { get; init; } = null!;
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
}
