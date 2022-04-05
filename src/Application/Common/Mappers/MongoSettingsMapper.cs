public static class MongoSettingsMapper
{
    public static MongoContainerSettings Map(ContainerVariableTable vars)
    {
        

        MongoContainerSettings settings = new()
        {
            ConnectionString = vars.Table["CONNECTIONSTRING"] ?? null,
            Username = vars.Table["USERNAME"] ?? null,
            Password = vars.Table["PASSWORD"] ?? null
        };
        return settings;
    }
}