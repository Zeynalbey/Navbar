using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DemoApplication.ViewComponents
{
    [ViewComponent(Name = "FooterNavbar")]
    public class FooterNavbarViewComponent : ViewComponent
    {
        private readonly DataContext _datacontext;
        public FooterNavbarViewComponent(DataContext datacontext)
        {
            _datacontext = datacontext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _datacontext.Navbars
                .Include(n => n.SubNavbars.OrderBy(sn => sn.Row))
                .Where(n => n.IsFooter)
                .OrderBy(n => n.Row)

                .ToList();

            return View("~/Views/Shared/Components/FooterNav/Index.cshtml", model);
        }
    }
}
