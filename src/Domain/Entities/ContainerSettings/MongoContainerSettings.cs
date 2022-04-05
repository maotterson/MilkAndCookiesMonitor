public record MongoContainerSettings : IContainerSettings
{
    public string? ConnectionString { get; init; }
}