using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.ViewComponents
{
    public class SearchVideoBarViewComponent : ViewComponent
    {

        public SearchVideoBarViewComponent()
        {
        }

        public IViewComponentResult Invoke(
        int maxPriority, bool isDone)
        {
            string items = "Ok";
            return View("Default", items);
        }
      
    }
}