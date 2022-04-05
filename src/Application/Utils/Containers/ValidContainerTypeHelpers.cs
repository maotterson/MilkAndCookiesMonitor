using MilkAndCookiesBlazor.Models.Containers.Enums;

namespace MilkAndCookiesBlazor.Utils.Containers
{
    public static class ValidContainerTypeHelpers
    {
        public static EValidContainer AsContainerType(this string type)
        {
            return Enum.Parse<EValidContainer>(type, true);
        }
    }
}
