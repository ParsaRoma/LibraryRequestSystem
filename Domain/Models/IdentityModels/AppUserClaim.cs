using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.IdentityModels
{
    public class AppUserClaim
    {
        public int id { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}