using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GuitarLocker.Models
{
    public class GuitarLockerUser : IdentityUser
    {
        public DateTime FirstInstrument { get; set; }
    }
}