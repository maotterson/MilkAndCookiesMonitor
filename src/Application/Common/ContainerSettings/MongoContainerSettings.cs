public record MongoContainerSettings : IContainerSettings
{
    public string Name { get; init; }
    public EValidContainer ContainerType { get; init; } = EValidContainer.MONGO;
    public ContainerVariable? ConnectionString { get; init; }
    public ContainerVariable? Username { get; init; }
    public ContainerVariable? Password { get; init; }
}