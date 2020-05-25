using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Navigation_menu
{
    class NavMenu
    {
        public List<NavItem> Items { get; set; }

        public NavMenu()
        {
            string filepath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Data\\Navigation.csv";
            CsvReader reader = new CsvReader(filepath);
            Items = reader.ReadNavItems();
        }

        public NavMenu(string filepath)
        {
            CsvReader reader = new CsvReader(filepath);
            Items = reader.ReadNavItems();
        }

        public void OrderList()
        {
            Items = Items.OrderBy(x => x.ParentID).ToList();
            foreach (var item in Items)
            {
                if (item.ParentID != 0)
                {
                    foreach (var parent in Items)
                    {
                        if (item.ParentID == parent.ID)
                        {
                            parent.AddChild(item);
                            break;
                        }
                    }
                }
            }
            Items.RemoveAll(x => x.ParentID != 0);
            Items = Items.OrderBy(x => x.MenuName).ToList();
        }

        public void Start()
        {
            OrderList();
            string dott = ". ";
            foreach (var item in Items)
            {
                item.Print(dott);
            }
        }
    }
}
