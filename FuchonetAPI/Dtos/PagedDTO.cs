namespace FuchonetAPI.Dtos
{
    public class PagedDTO
    {

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int TotalNumberOfRecords { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalNumberOfPages;



    }
}
