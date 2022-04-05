public record ContainerVariableTable
{
    public string Name { get; init; }
    public IDictionary<string, ContainerVariable> Table {get; init;}
}