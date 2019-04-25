using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class Video
    {
        public Video()
        {
            ComunidadeVideo = new HashSet<ComunidadeVideo>();
            VideoComments = new HashSet<VideoComments>();
            VideoRatings = new HashSet<VideoRatings>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Usuario { get; set; }
        public int? Views { get; set; }
        public DateTime? PostDate { get; set; }
        public int? Duration { get; set; }
        public int? AllowAds { get; set; }
        public string Description { get; set; }
        public int? Categoria { get; set; }

        public Categoria CategoriaNavigation { get; set; }
        public User UsuarioNavigation { get; set; }
        public ICollection<ComunidadeVideo> ComunidadeVideo { get; set; }
        public ICollection<VideoComments> VideoComments { get; set; }
        public ICollection<VideoRatings> VideoRatings { get; set; }
    }
}
