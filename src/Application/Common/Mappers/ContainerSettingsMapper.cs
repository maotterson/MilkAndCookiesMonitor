public class ContainerSettingsMapper : IContainerSettingsMapper
{
    private Dictionary<EValidContainer, Func<ContainerVariableTable, IContainerSettings>> Mapper = new()
    {
        { EValidContainer.MONGO, (settings) => MongoSettingsMapper.Map(settings) },
        { EValidContainer.REDIS, (settings) => RedisSettingsMapper.Map(settings) }
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
