using Microsoft.Extensions.Configuration;

public interface IContainerSettingsService
{
    public ContainerSettingsMasterList ExtractContainerSettingsList(IEnumerable<IConfigurationSection> containersConfig);
    public string DumpContainerSettingsInfo();
}