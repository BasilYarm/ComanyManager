using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyManager.Employees
{
    class HourlyEmployee : Employee
    {
        public string Post { get; set; }

        public double PaymentForHour { get; set; }

        public double FactorOfSuccess { get; set; }

        public int CountHour { get; set; }

        public HourlyEmployee(int id, string name, string post, int countHour, double paymentForHour)
            : base(id, name)
        {
            Post = post;

            PaymentForHour = paymentForHour;

            Random factorOfSuccess = new Random();

            FactorOfSuccess = (double)factorOfSuccess.Next(100) / 100;

            CountHour = countHour;
        }

        public override double ChargeOfWages(double profitOfTheCompany)
        {
            return CountHour * PaymentForHour * FactorOfSuccess;
        }
    }
}
