namespace Fuchonet.Repositories.Utils
{
    public class PagedResult<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int TotalNumberOfRecords { get; set; }
        
        public bool HasPrevious => (CurrentPage > 1);
        public bool HasNext => (CurrentPage < TotalNumberOfPages);


        public List<T> Results = new List<T>();
        //TODO:
        //CAMBIAR PAGESIZE PAGE NUMBER POR CURRENTPAGE
        //CAMBIAR NOMBRES DE PROPIEDADES A UNAS MAS LEGIBLES
        //AGREGAR MESSAGUE PARA COMMENTARIO OPCIONAL
        //
        
    }
}
