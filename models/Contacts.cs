using System.ComponentModel.DataAnnotations;

namespace api_sql_platzi.models
{
    public class Contacts
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}