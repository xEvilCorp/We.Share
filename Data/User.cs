using System;
using System.Collections.Generic;

namespace WeShare.Web.Data
{
    public partial class User
    {
        public User()
        {
            CanalUser = new HashSet<CanalUser>();
            ComunidadeVideo = new HashSet<ComunidadeVideo>();
            InscritosCanal = new HashSet<InscritosCanal>();
            InscritosComunidade = new HashSet<InscritosComunidade>();
            UserClaim = new HashSet<UserClaim>();
            UserLogin = new HashSet<UserLogin>();
            UserRole = new HashSet<UserRole>();
            UserToken = new HashSet<UserToken>();
            Video = new HashSet<Video>();
            VideoComments = new HashSet<VideoComments>();
            VideoRatings = new HashSet<VideoRatings>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int? AccessFailedCount { get; set; }

        public ICollection<CanalUser> CanalUser { get; set; }
        public ICollection<ComunidadeVideo> ComunidadeVideo { get; set; }
        public ICollection<InscritosCanal> InscritosCanal { get; set; }
        public ICollection<InscritosComunidade> InscritosComunidade { get; set; }
        public ICollection<UserClaim> UserClaim { get; set; }
        public ICollection<UserLogin> UserLogin { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
        public ICollection<UserToken> UserToken { get; set; }
        public ICollection<Video> Video { get; set; }
        public ICollection<VideoComments> VideoComments { get; set; }
        public ICollection<VideoRatings> VideoRatings { get; set; }
    }
}
