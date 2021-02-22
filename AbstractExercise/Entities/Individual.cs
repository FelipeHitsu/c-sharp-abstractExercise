using System;
using System.Globalization;
namespace AbstractExercise.Entities
{
    class Individual : TaxPayer
    {
        public double HealthExpenditures { get; set; }

        public Individual(string name,double anualIncome,double healthExpenditures) : base(name, anualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }
        public override double Tax()
        {
            double totalTax, discount;
            discount = 0;

            if(AnualIncome < 20000)
            {
                totalTax = AnualIncome * 0.20;
            }
            else
            {
                totalTax = AnualIncome * 0.25;
            }

            if(HealthExpenditures > 0)
            {
                discount = HealthExpenditures * 0.50;
            }

            return totalTax - discount;
        }
    }
}
