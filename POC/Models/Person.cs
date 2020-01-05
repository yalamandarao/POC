using System;
using Realms;

namespace POC.Models
{
    public class Person: RealmObject
    {
        
        [PrimaryKey]
        public string ContactNumber { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public bool IsEditEnabel { get; set; }

        public Person Copy()
        {
            return new Person
            {
                ContactNumber = ContactNumber,
                Name = Name ?? "",
                Address = Address ?? "",
                IsEditEnabel = IsEditEnabel
            };
        }
    }
}
