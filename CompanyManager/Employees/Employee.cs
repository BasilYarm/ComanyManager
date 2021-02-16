using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyManager.Employees
{
    abstract class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;

            Name = name;
        }

        public abstract double ChargeOfWages(double profitOfTheCompany);
    }
}
