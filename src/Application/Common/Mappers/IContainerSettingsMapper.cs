public interface IContainerSettingsMapper
{
    public Action<ContainerVariableTable> Map(EValidContainer validContainerType);
    public Action<ContainerVariableTable> TryMap(string containerType);
}
