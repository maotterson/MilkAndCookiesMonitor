using Microsoft.Extensions.Configuration;

public static class ContainerSettingsHelpers
{
    public static ContainerVariableTable AsContainerVariableTable(this IEnumerable<IConfigurationSection> configurationList, string containerName)
    {
        Dictionary<string,ContainerVariable> containerVariables = new();
        foreach(var setting in configurationList)
        {
            var name = setting.Key;
            var value = setting.Value;

            var currentVar = new ContainerVariable()
            {
                Name = name,
                Value = value
            };

            containerVariables.Add(currentVar.Name, currentVar);
        }

        var table = new ContainerVariableTable()
        {
            Name = containerName,
            Table = containerVariables
        };

        return table;
    }

    public static ContainerSettingsList AsContainerSettingsList(this IList<IContainerSettings> containerSettingsList)
    {
        var wrapperObject = new ContainerSettingsList()
        {
            List = containerSettingsList
        };
        return wrapperObject;
    }
}