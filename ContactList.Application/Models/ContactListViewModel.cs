using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Application.Models
{
    public class ContactListViewModel
    {
        [JsonProperty(PropertyName = "contactName")]       
        public string Name { get; set; }


        [JsonProperty(PropertyName = "Email")]      
        public string Email { get; set; }


        [JsonProperty(PropertyName = "phoneNumber")]       
        public string PhoneNumber { get; set; }


        [JsonProperty(PropertyName = "category [Eg: family, friend, work]")]      
        public string Category { get; set; }


        [JsonProperty(PropertyName = "birthDate")]
        public DateTime? Birthdate { get; set; }
    }
}
