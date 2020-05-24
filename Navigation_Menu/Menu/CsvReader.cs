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
            string[] parts = csvLine.Split(';');
            int ID = int.Parse(parts[0]);
            string MenuName = parts[1];

            bool ParID = int.TryParse(parts[2], out int ParentID);
            if (!ParID) ParentID = 0;

            bool IsHidden = bool.Parse(parts[3]);
            string LinkURL = parts[4];

            return new NavItem(ID, MenuName, ParentID, IsHidden, LinkURL);
        }
    }
}