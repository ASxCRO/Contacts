using System.ComponentModel.DataAnnotations;

namespace Contacts.API.Data.Entities
{
    public class Contact : BaseEntity<int>
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}