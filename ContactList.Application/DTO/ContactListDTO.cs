using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Application.DTO
{
    public  class ContactListDTO
    {
       
        

       
        public string Name { get; set; }

       
        public string Email { get; set; }

     
        public string PhoneNumber { get; set; }

       
        public string Category { get; set; }

       
        public DateTime? Birthdate { get; set; }
    }
}
