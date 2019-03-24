﻿using Cinrad.Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;

namespace Cinrad.Infrastructure.CrossCutting.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public override string UserName { get; set; }
        public override string Email { get; set; }

        public override int GetHashCode()
        {
            return (UserName.GetHashCode() * 907) + Id.GetHashCode();
        }
    }
}
