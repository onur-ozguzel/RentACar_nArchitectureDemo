namespace Core.Application.Pipelines.Caching
{
    public interface ICacheableRequest
    {
        string CacheKey { get; }
        bool BypassCache { get; }
        string? CacheGroupKey { get; }
        TimeSpan? SlidingExpiration { get; }
    }
}
