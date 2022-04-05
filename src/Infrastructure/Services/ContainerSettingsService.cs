using Microsoft.Extensions.Configuration;

public class ContainerSettingsService : IContainerSettingsService
{
    private IContainerSettingsMapper containerMapper;
    private ContainerSettingsMasterList allContainerSettings;
    public ContainerSettingsService(IContainerSettingsMapper containerMapper, IEnumerable<IConfigurationSection> containers)
    {
        this.containerMapper = containerMapper;
        this.allContainerSettings = ExtractContainerSettingsList(containers);
    }

    public ContainerSettingsMasterList ExtractContainerSettingsList(IEnumerable<IConfigurationSection> containersConfig)
    {
        IList<IContainerSettings> containerSettingsList = new List<IContainerSettings>();

        foreach (var containerConfig in containersConfig)
        {
            var containerType = containerConfig.Value.AsContainerType();
            var containerName = containerConfig.Key;
            var containerVars = containerConfig.GetChildren();

            var containerVarTable = containerVars.AsContainerVariableTable(containerName);
            var containerSettings = containerMapper.Map(containerType).Invoke(containerVarTable);

            containerSettingsList.Add(containerSettings);
        }

        return containerSettingsList.AsContainerSettingsList();
    }

    public string DumpContainerSettingsInfo()
    {
        return allContainerSettings.DumpContainerSettingsInfo();
    }
}