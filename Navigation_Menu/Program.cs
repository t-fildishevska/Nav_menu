using Navigation_menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            NavMenu menu;
            Console.WriteLine("Please choose one:");
            Console.WriteLine("1. Use embeded file");
            Console.WriteLine("2. Provide file path");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();

            if (choice == 2)
            {
                Console.WriteLine("Please enter file path (ex. C:\\Documents\\Navigation.csv):");
                string filepath = Console.ReadLine();
                menu = new NavMenu(filepath);
                Console.Clear();
            }
            else
            {
                menu = new NavMenu();
            }

            menu.Start();

            Console.ReadKey();
        }
    }
}
