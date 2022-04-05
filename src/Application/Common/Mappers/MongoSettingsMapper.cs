public static class MongoSettingsMapper
{
    public static MongoContainerSettings Map(ContainerVariableTable vars)
    {
        MongoContainerSettings settings = new()
        {
            ConnectionString = vars.MapValue("CONNECTIONSTRING"),
            Username = vars.MapValue("USERNAME"),
            Password = vars.MapValue("PASSWORD")
        };
        return settings;
    }
}