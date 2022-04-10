public interface IContainerRegistryService
{
    public ContainerServiceList ServiceList { get; init; }
    public IContainerService? GetServiceByContainerName(string containerName);
}
