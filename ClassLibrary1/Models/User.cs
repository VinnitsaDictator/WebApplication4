using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public class User : IdentityUser
    {
       
        public List<Ticket> Tickets { get; set; }
    }
}

