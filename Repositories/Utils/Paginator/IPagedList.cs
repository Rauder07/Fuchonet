namespace Fuchonet.Repositories.Utils
{
    public interface IPagedList
    {
        Task<PagedResult<T>> CreatedPageGenericResult<T>(
            IQueryable<T> queryable,
            int page,
            int pageSize,
            string ordeBy,
            bool ascending
            );
    }
}
