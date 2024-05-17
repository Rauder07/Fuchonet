
namespace Fuchonet.Dto.Response
{
    public class CustomerDTO
    {


        //public int Id { get; set; }
        public string FullName { get; set; }
        public string? Dni { get; set; }

        public List<PhoneDTO> Phones { get; set; } = new List<PhoneDTO> { };
        public List<AddressDTO> Address { get; set; } = new List<AddressDTO> { };
        
    }

}
