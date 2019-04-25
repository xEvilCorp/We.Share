﻿using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class UserToken
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public User User { get; set; }
    }
}
