using MilkAndCookiesBlazor.Models.Containers.Enums;
using MilkAndCookiesBlazor.Models.Containers.Settings;

namespace MilkAndCookiesBlazor.Mappers
{
    public interface IContainerSettingsMapper
    {
        public Action<IEnumerable<IVariable>> Map(EValidContainer validContainerType);
        public Action<IEnumerable<IVariable>> TryMap(string containerType);
    }
}
