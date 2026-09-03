namespace VitoSwimPT.Server.Infrastructure
{
    public abstract class PagedResult<T>
    {
        public int totalRecords { get; set; }
        public List<T> data { get; set; } = new();
    }
}
