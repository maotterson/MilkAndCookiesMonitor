using MilkAndCookiesBlazor.Mappers;
using MilkAndCookiesBlazor.Models;
using MilkAndCookiesBlazor.Models.Containers;
using MilkAndCookiesBlazor.Utils.Containers;

namespace MilkAndCookiesBlazor.Services
{
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

                var currentContainerVars = containerConfig.GetChildren();
                Console.WriteLine(containerType);
                Console.WriteLine(containerName);
                Console.WriteLine(currentContainerVars);

                

            }
        }
    }
}
