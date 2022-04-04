namespace MilkAndCookiesBlazor.Models.Containers.Settings
{
    public record Variable : IVariable
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
