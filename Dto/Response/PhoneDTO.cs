
namespace Fuchonet.Dto.Response
{
    public class PhoneDTO
    {
        
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public bool? IsActive { get; set; }
        public List<PhoneRelationshipDTO> PhoneRelationship { get; set; } = new List<PhoneRelationshipDTO> { };

    }
}
