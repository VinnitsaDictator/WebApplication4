using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}

