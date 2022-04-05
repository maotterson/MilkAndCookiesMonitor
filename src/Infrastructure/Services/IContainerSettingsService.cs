using Microsoft.Extensions.Configuration;

public interface IContainerSettingsService
{
    public void ExtractContainerSettings(IEnumerable<IConfigurationSection> containersConfig);
}