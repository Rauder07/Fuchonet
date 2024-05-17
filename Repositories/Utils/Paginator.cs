namespace Fuchonet.Repositories.Utils
{
    public class Paginator<T> : List<T>
    {
        public int CurrentPage { get; set; }
       
        public int TotalPage { get; set; }
        
        public int PageSize { get; set; }
        
        public int TotalCount { get; set; }
       
        public bool HasPrevious => CurrentPage > 1;

        public bool HasNext => CurrentPage < TotalPage;

        public Paginator(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }


    }
}
