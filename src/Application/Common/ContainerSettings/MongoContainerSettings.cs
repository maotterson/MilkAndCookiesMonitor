public record MongoContainerSettings : IContainerSettings
{
    public ContainerVariable? ConnectionString { get; init; }
}