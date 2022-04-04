using MilkAndCookiesBlazor.Models;
using MilkAndCookiesBlazor.Models.Containers;

namespace MilkAndCookiesBlazor.Services
{
    public interface IContainerSettingsService
    {
        public void ExtractContainerSettings(IEnumerable<IConfigurationSection> containersConfig);
    }
}
