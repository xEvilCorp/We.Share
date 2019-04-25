using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Hosting;

namespace WeShare.Web.Controllers
{
    public class AccountController : Controller
    {
        protected AppDbContext Context;
        protected UserManager<ApplicationUser> UserManager;
        protected SignInManager<ApplicationUser> SignInManager;
        protected IHostingEnvironment Env;

        public AccountController(
            AppDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHostingEnvironment env)
        {
            Context = context;
            UserManager = userManager;
            SignInManager = signInManager;
            Env = env;
        }

        [HttpGet]
        [Route("signup")]
        public IActionResult SignUp()
        {
            Context.Database.EnsureCreated();
            ViewBag.Genders = Context.Genders.ToList();
            return View();
        }

        [HttpPost]
        [Route("signup")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(int gender, string password, string password2, string username, string email, string firstname, string lastname)
        {

            if (isUserValid(gender, password, password2, username, email, firstname, lastname))
            {
                var appUser = new ApplicationUser
                {
                    UserName = username,
                    Email = email,
                    Gender = Context.Genders.Find(gender),
                    FirstName = firstname,
                    LastName = lastname
                };
                var result = await UserManager.CreateAsync(appUser, password);
                if (result.Succeeded)
                {
                    return Content("It worked", "text/html");
                }
            }
            else
            {
                return Content("Invalid Data", "text/html");
            }
            return Content("User creation failed", "text/html");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string ReturnUrl, string username, string password)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            var result = await SignInManager.PasswordSignInAsync(username, password, true, true);
            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    return RedirectToPage(ReturnUrl);
                }
                return Redirect("index");
            }
            return Content("Failed to Login", "text/html");
        }

        [Route("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Content("Logout Done", "text/html");
        }

        [HttpGet]
        [Authorize]
        [Route("account")]
        public async Task<IActionResult> Account()
        {
            if (SignInManager.IsSignedIn(HttpContext.User))
            {
                ViewBag.user = await UserManager.GetUserAsync(HttpContext.User);
            }
            return View();

        }

        [HttpGet]
        [Authorize]
        [Route("account/edit")]
        public async Task<IActionResult> EditAccount()
        {
            if (SignInManager.IsSignedIn(HttpContext.User))
            {
                ApplicationUser u = await UserManager.GetUserAsync(HttpContext.User);
                if(u.HasProfilePicture) {
                    ViewBag.userProfilePicturePath =  $@"/data/users/{u.Id}/profilePicture.jpg";
                } 
                ViewBag.user = u;
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        [Route("account/changeProfilePicture")]
        public async Task<IActionResult> ChangeProfilePicture(string profilePicture)
        {
            if (profilePicture != null && profilePicture.Length > 0)
            {
                //ApplicationUser user = await UserManager.FindByIdAsync(userId);
                ApplicationUser user = await UserManager.GetUserAsync(HttpContext.User);
                string filePath = $@"/data/users/{user.Id}/";
                string fileName = "profilePicture";
                string fileType = ".jpg";
                string file = Env.WebRootPath + filePath + fileName + fileType;
                 System.IO.FileInfo f = new System.IO.FileInfo(file);
                f.Directory.Create(); 
                user.HasProfilePicture = true;
                await System.IO.File.WriteAllBytesAsync(file, Convert.FromBase64String(profilePicture.Substring(23)));
                await UserManager.UpdateAsync(user);
                return Content("Profile picture updated.");
            }
            return Content("Upload of new profile picture failed 😢");
        }














        public bool isUserValid(int gender, string password, string password2, string username, string email, string firstname, string lastname)
        {
            if (password.Trim() == "" || password != password2) return false;
            if (username.Trim() == "" || username.Trim().Length <= 1) return false;
            if (firstname.Trim() == "" || firstname.Trim().Length <= 1) return false;
            if (lastname.Trim() == "" || lastname.Trim().Length <= 1) return false;
            if (email.Trim() == "" || email.Trim().Length <= 1 || email.IndexOf("@") == -1) return false;
            if (gender == 0) return false;
            if (UserManager.FindByNameAsync(username) != null) return false;
            if (UserManager.FindByEmailAsync(username) != null) return false;
            return true;
        }
    }
}




