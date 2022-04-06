public record MongoContainerSettings : IContainerSettings
{
    public string Name { get; init; } = null!;
    public EValidContainer ContainerType { get; init; } = EValidContainer.MONGO;
    public ContainerVariableTable VariableTable { get; init; } = null!;
    public ContainerVariable? ConnectionString { get; init; }
    public ContainerVariable? Username { get; init; }
    public ContainerVariable? Password { get; init; }
}
