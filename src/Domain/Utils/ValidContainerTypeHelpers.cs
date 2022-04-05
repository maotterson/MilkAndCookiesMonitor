public static class ValidContainerTypeHelpers
{
    public static EValidContainer AsContainerType(this string type)
    {
        return Enum.Parse<EValidContainer>(type, true);
    }
}
