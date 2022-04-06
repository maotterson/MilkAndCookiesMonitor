public static class RedisSettingsMapper
{
    public static RedisContainerSettings Map(ContainerVariableTable vars)
    {
        RedisContainerSettings settings = new()
        {
            Name = vars.Name,
            VariableTable = vars,
            ConnectionString = vars.MapValue("CONNECTIONSTRING"),
            Username = vars.MapValue("USERNAME"),
            Password = vars.MapValue("PASSWORD"),
        };
        return settings;
    }

}
