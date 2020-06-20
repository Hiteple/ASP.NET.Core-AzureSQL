using System.Collections;
using System.Collections.Generic;
using System.Linq;
using api_sql_platzi.models;
using Microsoft.AspNetCore.Mvc;

namespace api_sql_platzi.Controllers
{
    // 1 - Annotations
    [Route("[controller]")]
    [ApiController]
    public class ContactController: Controller
    {
        // 2 - Obtain the context and constructor
        private readonly ContactsContext _contactsContext;

        public ContactController(ContactsContext context)
        {
            _contactsContext = context;
        }

        // 3 - Get method and ActionResult
        [HttpGet]
        public ActionResult<IEnumerable<Contacts>> Get()
        {
            // ToList returns an array in json format for objects
            return _contactsContext.ContactSet.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Contacts> Get(string id)
        {
            var selectedContact = (from c in _contactsContext.ContactSet
                where c.Id == id
                select c).FirstOrDefault();

            return selectedContact;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contacts value)
        {
            Contacts newContact = value;
            _contactsContext.ContactSet.Add(newContact);
            _contactsContext.SaveChanges();
            return Ok("Contact added!");
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Contacts value)
        {
            var selectedElement = (from c in _contactsContext.ContactSet
                where c.Id == id
                select c).FirstOrDefault();
            if (selectedElement != null)
            {
                selectedElement.Name = value.Name;
                selectedElement.Email = value.Email;
                selectedElement.Phone = value.Phone;
                _contactsContext.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var selectedElement = _contactsContext.ContactSet.Find(id);
            _contactsContext.ContactSet.Remove(selectedElement);
            _contactsContext.SaveChanges();
            
            return Ok("Deleted correctly!");
        }
        
        // 4 - Destructure
        ~ContactController()
        {
            _contactsContext.Dispose();
        }
    }
}