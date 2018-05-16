using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Project
{
    class Menu
    {
        public static void Show()
        {
            Console.WriteLine("Make your choice again");
            Console.WriteLine("1-Add car to the parking");
            Console.WriteLine("2-Remove car from the parking");
            Console.WriteLine("3-Increase cars balanse by CarId");
            Console.WriteLine("4-Show transactions for last minute");
            Console.WriteLine("5-Show parkings earnings ");
            Console.WriteLine("6-Show parkings free places ");
            Console.WriteLine("7-Pull data from file to console");
            Console.WriteLine("0-Exit");
        }
    }
}
