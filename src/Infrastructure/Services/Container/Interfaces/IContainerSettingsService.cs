using Microsoft.Extensions.Configuration;

public interface IContainerSettingsService
{
    public ContainerSettingsMasterList ExtractContainerSettingsList(IEnumerable<IConfigurationSection> containersConfig);
    public ContainerSettingsMasterList SettingsRegistry { get; init; }
    public string DumpContainerSettingsInfo();
}
