public class MongoContainerService : IContainerService
{
    public IContainerSettings ContainerSettings { get; init; } = null!;

    public MongoContainerService(IContainerSettings settings)
    {
        ContainerSettings = settings;
    }
}
