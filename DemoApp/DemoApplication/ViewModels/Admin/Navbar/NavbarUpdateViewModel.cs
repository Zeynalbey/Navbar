namespace DemoApplication.ViewModels.Admin.Navbar
{
    public class NavbarUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Row { get; set; }
        public bool IsMain{ get; set; }
        public bool IsHeader { get; set; }
        public bool IsFooter { get; set; }

        public NavbarUpdateViewModel(int id, string name, int row, bool isMain, bool isHeader, bool isFooter)
        {
            Id = id;
            Name = Name;
            Row = row;
            IsMain = isMain;
            IsHeader = isHeader;
            IsFooter = isFooter;
        }

        public NavbarUpdateViewModel()
        {
        }
    }
}
