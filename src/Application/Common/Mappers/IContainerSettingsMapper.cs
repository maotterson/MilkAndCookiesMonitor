public interface IContainerSettingsMapper
{
    public Action<IEnumerable<ContainerVariable>> Map(EValidContainer validContainerType);
    public Action<IEnumerable<ContainerVariable>> TryMap(string containerType);
}
