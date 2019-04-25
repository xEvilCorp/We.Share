using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Categoria
    {
        public Categoria()
        {
            Video = new HashSet<Video>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Icone { get; set; }

        public ICollection<Video> Video { get; set; }
    }
}
