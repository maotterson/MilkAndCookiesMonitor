using Microsoft.Extensions.Configuration;

public interface IContainerSettingsService
{
    public ContainerSettingsList ExtractContainerSettingsList(IEnumerable<IConfigurationSection> containersConfig);
    public string DumpContainerSettingsInfo();
}