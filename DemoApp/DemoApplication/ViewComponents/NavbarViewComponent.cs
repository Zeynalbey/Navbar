using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DemoApplication.ViewComponents
{
    [ViewComponent(Name = "Navbar")]
    public class NavbarViewComponent : ViewComponent
    {
        private readonly DataContext _datacontext;
        public NavbarViewComponent(DataContext datacontext)
        {
            _datacontext = datacontext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model= _datacontext.Navbars
                .Include(n=>n.SubNavbars.OrderBy(sn=>sn.Row))
                .Where(n=> n.IsHeader)
                .OrderBy(n => n.Row)            
                .ToList();

            return View("~/Views/Shared/Components/Navbar/Index.cshtml", model);
        }
    }
}
