using Contacts.API.Data.Entities;

namespace Contacts.API.Models
{
    public class ContactGridViewModel : GridPager
    {
        public IEnumerable<Contact> Contacts { get; set; }
    }
}