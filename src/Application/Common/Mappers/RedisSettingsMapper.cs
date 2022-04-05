public static class RedisSettingsMapper
{
    public static RedisContainerSettings Map(ContainerVariableTable vars)
    {
        RedisContainerSettings settings = new()
        {
            ConnectionString = vars.Table["CONNECTIONSTRING"] ?? null,
            Username = vars.Table["USERNAME"] ?? null,
            Password = vars.Table["Password"] ?? null
        };
        return settings;
    }
}