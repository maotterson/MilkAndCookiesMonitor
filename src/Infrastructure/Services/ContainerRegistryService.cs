public class ContainerRegistryService : IContainerRegistryService
{
    public ContainerServiceList ServiceList { get; init; } = null!;
    public ContainerRegistryService(ContainerSettingsMasterList settings)
    {
        ServiceList = ContainerServiceFactory.CreateContainerServiceList(settings);
    }
}
