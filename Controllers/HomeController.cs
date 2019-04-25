using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WeShare.Web.Controllers
{
    public class HomeController : Controller
    {
        protected AppDbContext Context;
        protected UserManager<ApplicationUser> UserManager;
        protected SignInManager<ApplicationUser> SignInManager;

        public HomeController(
            AppDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) 
        {
            Context = context;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Context.Database.EnsureCreated();
            return View();
        }
        
        
    }
}