using Microsoft.AspNetCore.Identity;
using System;

namespace Cinrad.Infrastructure.CrossCutting.Identity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
        public ApplicationRole(string name, string description)
        {
            Name = name;         
            Description = description;
        }
    }
}
