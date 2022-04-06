public interface IContainerSettings
{
    public string Name { get; init; }
    public EValidContainer ContainerType { get; init; }

    public ContainerVariableTable VariableTable { get; init; }
}
