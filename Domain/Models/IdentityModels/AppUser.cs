
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models.IdentityModels
{
    public class AppUser: IdentityUser<int>
    {
        public string?  FullName { get; set; }
        public DateTime DataCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}