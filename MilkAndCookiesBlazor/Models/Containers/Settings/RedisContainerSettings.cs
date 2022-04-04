namespace MilkAndCookiesBlazor.Models.Containers.Settings
{
    public record RedisContainerSettings : IContainerSettings
    {
        public IVariable? ConnectionString { get; init; }
    }
}
