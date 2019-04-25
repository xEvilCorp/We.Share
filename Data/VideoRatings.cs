using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class VideoRatings
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int? Value { get; set; }
        public int? Video { get; set; }

        public User UserNavigation { get; set; }
        public Video VideoNavigation { get; set; }
    }
}
