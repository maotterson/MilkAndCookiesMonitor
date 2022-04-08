public static class ContainerServiceFactory
{
    public static ContainerServiceList CreateContainerServiceList(ContainerSettingsMasterList masterSettingsList)
    {
        var serviceList = new List<IContainerService>();
        foreach(var setting in masterSettingsList.List)
        {
            var container = CreateContainerService(setting);
            serviceList.Add(container);
        }

        var serviceListWrapper = new ContainerServiceList()
        {
            List = serviceList
        };
        return serviceListWrapper;
    }
    public static IContainerService CreateContainerService(IContainerSettings settings) => settings.ContainerType switch
    {
        EValidContainer.REDIS => new RedisContainerService(settings),
        EValidContainer.MONGO => new MongoContainerService(settings),
        _ => throw new ContainerNotSupportedException()
    };
}
