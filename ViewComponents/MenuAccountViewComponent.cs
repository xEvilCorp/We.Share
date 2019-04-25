using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeShare.Web;

namespace First.ViewComponents
{
    public class MenuAccountViewComponent : ViewComponent
    {

        protected AppDbContext Context;
        protected UserManager<ApplicationUser> UserManager;
        protected SignInManager<ApplicationUser> SignInManager;

        public MenuAccountViewComponent(
            AppDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            Context = context;
            UserManager = userManager;
            SignInManager = signInManager;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {   
            ApplicationUser user = null;
            if(SignInManager.IsSignedIn(HttpContext.User)) {
                user = await UserManager.GetUserAsync(HttpContext.User);
                return View("Default", user);
            }
            else{return View("Default", user);}
        }
    }
}