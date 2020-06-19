using Microsoft.EntityFrameworkCore;

namespace api_sql_platzi.models
{
    public class ContactsContext: DbContext
    {
        public ContactsContext(DbContextOptions options): base(options)
        {
            
        }
        
        // This will be where all the data comes
        public DbSet<Contacts> ContactSet { get; set; }
    }
}