using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompanyManager.Employees;

namespace CompanyManager.MyCompany
{
    class Company
    {
        public static int NumberOfTheEmployee = 0;

        public string NameCompany{ get; set; }

        public Posts Post { get; set; }

        public CEO Ceo {get; set; }

        public double ProfitOfTheCompany { get; set; }

        public List<Manager> managers;

        public List<HourlyEmployee> hourlyEmployees;

        public List<SalariedEmployee> salariedEmployees;

        public Company(string nameCompany)
        {
            NameCompany = nameCompany;

            managers = new List<Manager>();

            hourlyEmployees = new List<HourlyEmployee>();

            salariedEmployees = new List<SalariedEmployee>();

            Random profitOfTheCompany = new Random();

            ProfitOfTheCompany = (double)profitOfTheCompany.Next(100000);
        }
    }

    enum Posts
    {
        staffmanager,
        salesmanager,
        superintendent,
        engineer,
        master,
        worker
    }
}
