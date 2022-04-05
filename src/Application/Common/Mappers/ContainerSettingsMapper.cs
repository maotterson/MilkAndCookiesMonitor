public class ContainerSettingsMapper : IContainerSettingsMapper
{
    private Dictionary<EValidContainer, Action<ContainerVariableTable>> Mapper = new()
    {
        { EValidContainer.MONGO, (settings) => MongoSettingsMapper.Map(settings) },
        { EValidContainer.REDIS, (settings) => RedisSettingsMapper.Map(settings) }
    };
    public Action<ContainerVariableTable> TryMap(string containerType)
    {
        var validContainerType = containerType.AsContainerType();
        return Mapper[validContainerType] ?? throw new ContainerNotSupportedException();
    }

    public Action<ContainerVariableTable> Map(EValidContainer validContainerType)
    {
        return Mapper[validContainerType] ?? throw new ContainerNotSupportedException();
    }
    
}
