using MilkAndCookiesBlazor.Models.Containers.Enums;
using MilkAndCookiesBlazor.Models.Containers.Settings;
using System.Runtime.Serialization;

namespace MilkAndCookiesBlazor.Mappers
{
    public class ContainerSettingsMapper : IContainerSettingsMapper
    {
        private Dictionary<EValidContainer, Action<IEnumerable<IVariable>>> Mapper = new()
        {
            { EValidContainer.MONGO, (x) => new MongoContainerSettings() },
            { EValidContainer.REDIS, (x) => new RedisContainerSettings() }
        };
        public Action<IEnumerable<IVariable>> TryMap(string containerType)
        {
            containerType.AsValidType()
            return Mapper[validContainerType] ?? throw new NotImplementedContainerException();
        }

        public Action<IEnumerable<IVariable>> Map(EValidContainer validContainerType)
        {
            return Mapper[validContainerType] ?? throw new NotImplementedContainerException();
        }
        internal class NotImplementedContainerException : Exception
        {
            public NotImplementedContainerException() : base("Container not implemented")
            {
            }
        }
    }
}
