public class RedisContainerService : IContainerService
{
    public RedisContainerSettings ContainerSettings { get; init; } = null!;

    public RedisContainerService(IContainerSettings settings)
    {
        ContainerSettings = (RedisContainerSettings)settings;
    }
    IContainerSettings IContainerService.GetSettings() => ContainerSettings;
}
