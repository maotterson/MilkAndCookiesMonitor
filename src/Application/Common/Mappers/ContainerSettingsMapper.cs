public class ContainerSettingsMapper : IContainerSettingsMapper
{
    private Dictionary<EValidContainer, Action<IEnumerable<ContainerVariable>>> Mapper = new()
    {
        { EValidContainer.MONGO, (settings) => MongoSettingsMapper.Map(settings) },
        { EValidContainer.REDIS, (settings) => RedisSettingsMapper.Map(settings) }
    };
    public Action<IEnumerable<ContainerVariable>> TryMap(string containerType)
    {
        var validContainerType = containerType.AsContainerType();
        return Mapper[validContainerType] ?? throw new ContainerNotSupportedException();
    }

    public Action<IEnumerable<ContainerVariable>> Map(EValidContainer validContainerType)
    {
        return Mapper[validContainerType] ?? throw new ContainerNotSupportedException();
    }
    
}
