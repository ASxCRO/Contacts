using Contacts.API.Data.Entities;
using Contacts.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactsRepository;

        public ContactController(IContactRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        [HttpGet]
        public IActionResult Index(string term = "", int pageNumber = 1, int pageSize = 12, string sortField = "FirstNameAsc")
        {
            int totalCount;

            if (string.IsNullOrWhiteSpace(term)) totalCount = _contactsRepository.CountAll();
            else totalCount = _contactsRepository.CountByTerm(term);

            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            if (pageNumber > totalPages) pageNumber = 1;

            var contactGridViewModel = new ContactGridViewModel
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                Sort = sortField,
                SearchTerm = term,
                TotalItemsNumber = totalCount,
                Contacts = _contactsRepository.FindAll(pageNumber, pageSize, sortField, term)
            };

            
            return Ok(contactGridViewModel);
        }


        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var id = _contactsRepository.Add(contact);
                return Ok(id);
            }

            
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactsRepository.Update(contact);
            }

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactsRepository.Remove(id);
            return Ok();
        }
    }
}