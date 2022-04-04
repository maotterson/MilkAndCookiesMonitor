namespace MilkAndCookiesBlazor.Models.Containers.Settings
{
    public record MongoContainerSettings : IContainerSettings
    {
        public IVariable? ConnectionString { get; init; }
    }
}
