public interface IContainerSettingsMapper
{
    public Func<ContainerVariableTable, IContainerSettings> Map(EValidContainer validContainerType);
    public Func<ContainerVariableTable, IContainerSettings> TryMap(string containerType);
}
