public static class MongoSettingsMapper
{
    public static MongoContainerSettings Map(ContainerVariableTable vars)
    {
        MongoContainerSettings settings = new()
        {
            ConnectionString = vars.Table["CONNECTIONSTRING"] ?? null
        };
        return settings;
    }
}