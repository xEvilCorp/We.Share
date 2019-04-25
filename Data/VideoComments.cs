using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class VideoComments
    {
        public VideoComments()
        {
            InverseRelatedToNavigation = new HashSet<VideoComments>();
        }

        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Comentario { get; set; }
        public int? RelatedTo { get; set; }
        public DateTime? PostDate { get; set; }
        public int? Video { get; set; }

        public VideoComments RelatedToNavigation { get; set; }
        public User UsuarioNavigation { get; set; }
        public Video VideoNavigation { get; set; }
        public ICollection<VideoComments> InverseRelatedToNavigation { get; set; }
    }
}
