using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WeShare.Web
{
    public class ApplicationUser : IdentityUser
    {   
        public Gender Gender {get; set;}
        public string FirstName {get; set;}
        public int GenderId {get; set;}
        public string LastName {get; set;}
        public bool HasProfilePicture {get;set;}
    }
}