public class ContainerSettingsMapper : IContainerSettingsMapper
{
    private Dictionary<EValidContainer, Func<ContainerVariableTable, IContainerSettings>> Mapper = new()
    {
        { EValidContainer.MONGO, (settingsTable) => MongoSettingsMapper.Map(settingsTable) },
        { EValidContainer.REDIS, (settingsTable) => RedisSettingsMapper.Map(settingsTable) }
    };
    public Func<ContainerVariableTable, IContainerSettings> TryMap(string containerType)
    {
        var validContainerType = containerType.AsContainerType();
        return Mapper[validContainerType] ?? throw new ContainerNotSupportedException();
    }

    public Func<ContainerVariableTable, IContainerSettings> Map(EValidContainer validContainerType)
    {
        return Mapper[validContainerType] ?? throw new ContainerNotSupportedException();
    }
    
}
