public static class ContainerMapperHelpers
{
    internal static ContainerVariable? MapValue(this ContainerVariableTable vars, string variableHeader)
    {
        return vars.Table.TryGetValue(variableHeader, out var value) ? value : null;
    }
}
