public record ContainerSettingsMasterList
{
    public IList<IContainerSettings> List { get; init; } = null!;

    public string DumpContainerSettingsInfo()
    {
        string dump = "";
        foreach (var item in List)
        {
            dump += $"Container Name: {item.Name}\n" +
                    $"Type: {item.ContainerType}\n";
        }
        return dump;
    }
}