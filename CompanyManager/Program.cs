using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompanyManager.MyCompany;

namespace CompanyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementOfTheCompany theOwner = new ManagementOfTheCompany();

            theOwner.Run();

            Console.ReadKey();
        }
    }
}
