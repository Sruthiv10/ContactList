using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Application.Models
{
    public  class ContactListEditModel
    {
        [JsonProperty(PropertyName = "contactId")]
        [Required]
        [StringLength(100)]
        public string ContactId { get; set; }

        [JsonProperty(PropertyName = "contactName")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "Email")]
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phoneNumber")]
        [Required]
        [StringLength(100)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "category [Eg: family, friend, work]")]
        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "birthDate")]

        public DateTime? Birthdate { get; set; }
    }
}
