public record ContainerSettingsMasterList
{
    private IList<IContainerSettings> list { get; init; } = null!;

    public string DumpContainerSettingsInfo()
    {
        string dump = "";
        foreach (var item in list)
        {
            dump += $"Container Name: {item.Name}\n" +
                    $"Type: {item.ContainerType}\n";
        }
        return dump;
    }

    public IList<IContainerSettings> Get()
    {
        return list;
    }
}
