using System.ComponentModel.DataAnnotations;

namespace SampleApi3.DTO
{
    public class DTOSystemRole
    {
        [Key]
        public int Id { get; set; }
        [Required, Base64String, StringLength(255), MinLength(10) ]
        public string SystemRole { get; set; }
        [Base64String]
        public string SystemRoleDescription { get; set; }
    }
}
