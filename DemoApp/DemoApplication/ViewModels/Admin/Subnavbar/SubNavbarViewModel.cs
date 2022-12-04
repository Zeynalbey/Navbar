namespace DemoApplication.ViewModels.Admin.SubNavbar
{
    public class SubNavbarViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public SubNavbarViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
