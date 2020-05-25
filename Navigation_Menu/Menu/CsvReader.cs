using System.Collections.Generic;
using System.IO;

namespace Navigation_menu
{
    class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }
        
        public List<NavItem> ReadNavItems()
        {
            List<NavItem> NavItems = new List<NavItem>();

            using(StreamReader sr = new StreamReader(_csvFilePath))
            {
                sr.ReadLine();
                string csvLine;
                while ((csvLine = sr.ReadLine()) != null)
                {
                    NavItems.Add(ReadNavItemFromCsvLine(csvLine));
                }
            }

            return NavItems;
        }

        public NavItem ReadNavItemFromCsvLine(string csvLine)
        {
            var navItem = new NavItem();
            string[] parts = csvLine.Split(';');

            navItem.ID = int.Parse(parts[0]);
            navItem.MenuName = parts[1];

            bool ParID = int.TryParse(parts[2], out int ParentID);
            if (ParID)
            {
                navItem.ParentID = ParentID;
            }
            else
            {
                navItem.ParentID = 0;
            }

            navItem.IsHidden = bool.Parse(parts[3]);
            navItem.LinkURL = parts[4];

            return navItem;
        }
    }
}