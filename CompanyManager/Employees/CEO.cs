using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyManager.Employees
{
    class CEO : Employee
    {
        public double TheRate { get; set; }

        public CEO(int id, string name, double theRate)
            : base(id, name)
        {
            TheRate = theRate;
        }

        public override double ChargeOfWages(double profitOfTheCompany)
        {
            return TheRate + (10 * profitOfTheCompany) / 100;
        }
    }
}
