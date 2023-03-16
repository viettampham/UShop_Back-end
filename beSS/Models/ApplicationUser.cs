using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace beSS.Models
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Bill> Bills { get; set; }
    }
}