public class ContainerRegistryService : IContainerRegistryService
{
    public ContainerServiceList ServiceList { get; init; } = null!;
    public ContainerRegistryService(ContainerSettingsMasterList settings)
    {
        ServiceList = ContainerServiceFactory.CreateContainerServiceList(settings);
    }

    public IContainerService? GetServiceByContainerName(string containerName)
    {
        var service = ServiceList.List.FirstOrDefault(current =>
        {
            return current.ContainerSettings.Name == containerName;
        });

        return service;
    }
}
