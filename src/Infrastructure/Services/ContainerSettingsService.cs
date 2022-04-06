using Microsoft.Extensions.Configuration;

public class ContainerSettingsService : IContainerSettingsService
{
    private IContainerSettingsMapper containerMapper;
    public ContainerSettingsMasterList SettingsRegistry { get; init; } = null!;
    public ContainerSettingsService(IContainerSettingsMapper mapper, IEnumerable<IConfigurationSection> containers)
    {
        containerMapper = mapper;
        SettingsRegistry = ExtractContainerSettingsList(containers);
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
        return SettingsRegistry.DumpContainerSettingsInfo();
    }

}
