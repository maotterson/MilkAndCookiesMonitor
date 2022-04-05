using Microsoft.Extensions.Configuration;

public static class ContainerSettingsHelpers
{
    public static ContainerVariableTable AsContainerVariableTable(this IEnumerable<IConfigurationSection> configurationList)
    {
        HashSet<ContainerVariable> containerVariables = new();
        foreach(var setting in configurationList)
        {
            var name = setting.Key;
            var value = setting.Value;

            var currentVar = new ContainerVariable()
            {
                Name = name,
                Value = value
            };

            containerVariables.Add(currentVar);
        }

        var table = new ContainerVariableTable()
        {
            Table = containerVariables
        };

        return table;
    }
}