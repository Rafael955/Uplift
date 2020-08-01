using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Uplift.Models.ValueObjects;

namespace Uplift.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public Name Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
