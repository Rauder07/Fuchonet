namespace Fuchonet.Dto.Request
{
    //PARAMETROS que va a enviar el cliente para la paginacion
    public class PaginationParams
    {
        private const int maxPageSize = 50;
        private int _pageSize = 10;
        public int PageNumber { get; set; } = 1;
        
        public string? OrderBy { get; set; }
        public bool OrderAsc { get; set; } = true;
        public int PageSize 
        { 
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
  

    }
}
