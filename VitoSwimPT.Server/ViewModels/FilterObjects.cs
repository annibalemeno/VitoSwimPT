namespace VitoSwimPT.Server.ViewModels
{
    public class FilterObjects
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string sortField { get; set; } = "Name";
        public int sortOrder { get; set; } = 1; // 1 as
        public string? globalFilter { get; set; }
    }

    public class FilterField
    {
        public string? value { get; set; }
        public string matchMode { get; set; }
    }
}
