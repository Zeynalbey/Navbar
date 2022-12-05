using DemoApplication.Database;
using DemoApplication.Database.Models;

using DemoApplication.ViewModels.Admin.Navbar;
using DemoApplication.ViewModels.Admin.Subnavbar;
using DemoApplication.ViewModels.Admin.SubNavbar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DemoApplication.Controllers.Admin
{
    [Route("Subnavbar")]
    public class SubNavbarController : Controller
    {
        private readonly DataContext _dataContext;
        public SubNavbarController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("list", Name = "Subnavbar-list")]
        public IActionResult List()

        {
            var model = _dataContext.SubNavbars.Select(s => new SubNavbarListViewModel(s.Id, s.Navbar.Name, s.Name, s.ToUrl, s.Row)).ToList();

            return View("~/Views/Admin/Subnavbar/List.cshtml", model);
        }

        #region Add

        [HttpGet("add", Name = "subnavbar-add")]
        public IActionResult Add()
        {
            var model = new ViewModels.Admin.Subnavbar.AddviewModel
            {
                Navbars = _dataContext.Navbars.Select(n => new SubNavbarViewModel(n.Id, n.Name)).ToList()
            };

            return View("~/Views/Admin/Subnavbar/Add.cshtml", model);
        }



        [HttpPost("add", Name = "subnavbar-add")]
        public IActionResult Add(ViewModels.Admin.Subnavbar.AddviewModel model)
        {
            var subnavbar = new SubNavbar
            {
                Name = model.Name,
                NavbarId = model.NavbarId,
                ToUrl = model.ToUrl,
                Row = model.Row
            };

            _dataContext.SubNavbars.Add(subnavbar);
            _dataContext.SaveChanges();

            return RedirectToRoute("Subnavbar-list");
        }

        #endregion

        #region Update

        [HttpGet("update/{id}", Name = "subnavbar-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id)
        {
            var subnavbar = await _dataContext.SubNavbars.FirstOrDefaultAsync(b => b.Id == id);
            if (subnavbar is null)
            {
                return NotFound();
            }

            var model = new UpdateViewModel
            {

                Name = subnavbar.Name,
                ToUrl = subnavbar.ToUrl,
                NavbarId = subnavbar.NavbarId,
                Row = subnavbar.Row,
                Navbar =
                    _dataContext.Navbars
                        .Select(n => new SubNavbarViewModel(n.Id, n.Name)).ToList()
            };

            return RedirectToRoute("subnavbar-update");
        }

        [HttpPost("update/{id}", Name = "subnavbar-update")]
        public IActionResult Update(UpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {

                model.Navbar = _dataContext.Navbars.Select(s => new SubNavbarViewModel(s.Id, s.Name)).ToList();
                return View("~/Views/Admin/Subnavbar/update.cshtml", model);
            }
            var subnavbar = _dataContext.SubNavbars.Include(n => n.Navbar).FirstOrDefault(s => s.Id == model.Id);
            if (subnavbar is null)
            {
                return NotFound();
            }

            subnavbar.Name = model.Name;
            subnavbar.Row = model.Row;
            subnavbar.ToUrl = model.ToUrl;
            subnavbar.NavbarId = model.NavbarId;

            _dataContext.SaveChanges();
            return RedirectToRoute("Subnavbar-list");
        }
        

        #endregion

        #region Delete

        [HttpPost("delete/{id}", Name = "subnavbar-delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var subnavbar = await _dataContext.SubNavbars.FirstOrDefaultAsync(s => s.Id == id);
            if (subnavbar is null)
            {
                return NotFound();
            }

            _dataContext.SubNavbars.Remove(subnavbar);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("Subnavbar-list");
        }

        #endregion
    }
}
