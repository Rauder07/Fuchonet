using FuchonetAPI.Models;

namespace FuchonetAPI.Dtos
{
    public class CustomerToListDTO
    {


        //public int Id { get; set; }
        public string FullName { get; set; }
        public string? Dni { get; set; }

        public List<PhonesToListDTO> phones { get; set; } = new List<PhonesToListDTO> { };
        
    }

}
