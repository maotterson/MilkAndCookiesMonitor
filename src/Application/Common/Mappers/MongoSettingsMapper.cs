public static class MongoSettingsMapper
{
    public static MongoContainerSettings Map(ContainerVariableTable vars)
    {
        MongoContainerSettings settings = new()
        {
            Name = vars.Name,
            ConnectionString = vars.MapValue("CONNECTIONSTRING"),
            Username = vars.MapValue("USERNAME"),
            Password = vars.MapValue("PASSWORD")
        };
        return settings;
    }
}