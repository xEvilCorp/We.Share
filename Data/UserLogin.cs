﻿using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class UserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
