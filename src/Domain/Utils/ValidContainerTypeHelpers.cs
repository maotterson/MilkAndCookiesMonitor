public static class ValidContainerTypeHelpers
{
    public static EValidContainer AsContainerType(this string type)
    {
        return Enum.Parse<EValidContainer>(type, true);
    }

    public static ContainerVariable AsContainerVariable(this string variable)
    {
        ContainerVariable var = new()
        {
            Name = variable,
            Value = variable
        };
        return var;
    }
}
