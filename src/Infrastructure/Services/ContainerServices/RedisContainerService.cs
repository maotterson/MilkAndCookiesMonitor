public class RedisContainerService : IContainerService
{
    public IContainerSettings ContainerSettings { get; init; } = null!;

    public RedisContainerService(IContainerSettings settings)
    {
        ContainerSettings = settings;
    }
}
