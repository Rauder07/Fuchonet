namespace Fuchonet.Dto.Response
{
    public class PaginationMedaDataDTO
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int TotalNumberOfRecords { get; set; }
        
        public bool HasPrevious => (CurrentPage > 1);
        public bool HasNext => (CurrentPage < TotalNumberOfPages);


       
        //TODO:
        //CAMBIAR PAGESIZE PAGE NUMBER POR CURRENTPAGE
        //CAMBIAR NOMBRES DE PROPIEDADES A UNAS MAS LEGIBLES
        //AGREGAR MESSAGUE PARA COMMENTARIO OPCIONAL
        //
        
    }
}
