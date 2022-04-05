public record ContainerVariableTable
{
    public string Name { get; init; } = null!;
    public IDictionary<string, ContainerVariable> Table { get; init; } = null!;
}