using Microsoft.Extensions.Configuration;

public class ContainerSettingsService : IContainerSettingsService
{
    private IContainerSettingsMapper containerMapper;
    public ContainerSettingsService(IContainerSettingsMapper containerMapper, IEnumerable<IConfigurationSection> containers)
    {
        this.containerMapper = containerMapper;
        ExtractContainerSettings(containers);
    }

    public void ExtractContainerSettings(IEnumerable<IConfigurationSection> containersConfig)
    {
        foreach (var containerConfig in containersConfig)
        {
            var containerType = containerConfig.Value.AsContainerType();
            var containerName = containerConfig.Key;
            var containerVars = containerConfig.GetChildren();

            var containerVarTable = containerVars.AsContainerVariableTable();
            var containerSettings = containerMapper.Map(containerType).Invoke(containerVarTable);

            Console.WriteLine(containerSettings);

        }
    }
}