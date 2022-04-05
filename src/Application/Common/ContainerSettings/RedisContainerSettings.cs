public record RedisContainerSettings : IContainerSettings
{
    public string Name { get; init; }
    public EValidContainer ContainerType { get; init; } = EValidContainer.REDIS;
    public ContainerVariable? ConnectionString { get; init; }
}