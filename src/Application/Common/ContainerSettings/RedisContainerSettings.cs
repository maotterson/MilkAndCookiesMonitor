public record RedisContainerSettings : IContainerSettings
{
    public ContainerVariable? ConnectionString { get; init; }
}