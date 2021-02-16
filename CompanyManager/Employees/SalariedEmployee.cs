using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyManager.Employees
{
    class SalariedEmployee : Employee
    {
        public string Post { get; set; }

        public double FactorOfSuccess { get; set; }

        public double TheRate { get; set; }

        public SalariedEmployee(int id, string name, string post, double theRate)
            : base(id, name)
        {
            Post = post;

            Random factorOfSuccess = new Random();

            FactorOfSuccess = (double)factorOfSuccess.Next(100) / 100;

            TheRate = theRate;
        }

        public override double ChargeOfWages(double profitOfTheCompany)
        {
            return TheRate * FactorOfSuccess;
        }
    }
}
