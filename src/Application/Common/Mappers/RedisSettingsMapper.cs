public static class RedisSettingsMapper
{
    public static RedisContainerSettings Map(ContainerVariableTable vars)
    {
        RedisContainerSettings settings = new()
        {
            ConnectionString = vars.Table["CONNECTIONSTRING"] ?? null
        };
        return settings;
    }
}