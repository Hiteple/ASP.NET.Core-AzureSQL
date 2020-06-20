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
        
        // 4 - Destructure
        ~ContactController()
        {
            _contactsContext.Dispose();
        }
    }
}