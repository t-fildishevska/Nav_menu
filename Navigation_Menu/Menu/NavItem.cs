using System;
using System.Collections.Generic;
using System.Linq;

namespace Navigation_menu
{
    public class NavItem
    {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public int ParentID { get; set; }
        public bool IsHidden { get; set; }
        public string LinkURL { get; set; }
        public List<NavItem> ChildItems { get; set; }

        public void AddChild(NavItem child)
        {
            if (ChildItems == null)
            {
                ChildItems = new List<NavItem>();
            }
            ChildItems.Add(child);
            ChildItems = ChildItems.OrderBy(x => x.MenuName).ToList();
        }

        public void Print(string indent)
        {
            Console.WriteLine(indent + MenuName);
            if (ChildItems != null)
            {
                foreach (var child in ChildItems)
                {
                    if (!child.IsHidden)
                    {
                        child.Print("..." + indent);
                    }
                }
            }
        }
    }
}