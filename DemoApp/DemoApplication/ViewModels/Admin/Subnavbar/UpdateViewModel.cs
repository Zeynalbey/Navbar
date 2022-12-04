using DemoApplication.ViewModels.Admin.Subnavbar;

namespace DemoApplication.ViewModels.Admin.SubNavbar
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ToUrl { get; set; }
        public int Row { get; set; }

        public int NavbarId { get; set; }
        public List<SubNavbarViewModel>? Navbar { get; set; }
    }
}
