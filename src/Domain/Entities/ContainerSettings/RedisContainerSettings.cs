namespace MilkAndCookiesBlazor.Models.Containers.Settings
{
    public record RedisContainerSettings : IContainerSettings
    {
        public string? ConnectionString { get; init; }
    }
}
