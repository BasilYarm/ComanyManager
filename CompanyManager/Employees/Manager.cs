using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyManager.Employees
{
    class Manager : Employee
    {
        public double FactorOfSuccess { get; set; }

        public string Specialization { get; set; }

        public double TheRate { get; set; }

        public Manager(int id, string name, string specialization, double theRate)
            : base(id, name)
        {
            Specialization = specialization;

            Random factorOfSuccess = new Random();

            FactorOfSuccess = (double)factorOfSuccess.Next(100) / 100;

            TheRate = theRate;
        }

        public override double ChargeOfWages(double profitOfTheCompany)
        {
            return (TheRate + (2 * profitOfTheCompany) / 100) * FactorOfSuccess;
        }
    }
}
