using System;
using System.Collections.Generic;
using System.Globalization;
using AbstractExercise.Entities;

namespace AbstractExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> Payers = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data: ");
                Console.Write("Individual or company (i/c)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double income = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                if(ch == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpends = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    Payers.Add(new Individual(name, income, healthExpends));
                }
                else
                {
                    Console.Write("Number of Employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    Payers.Add(new Company(name, income, numberOfEmployees));
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID");
            double totalPaidTaxes = 0;
            foreach(TaxPayer taxPayer in Payers)
            {
                Console.WriteLine(taxPayer.Name + ": $ " + taxPayer.Tax().ToString("F2",CultureInfo.InvariantCulture));
                totalPaidTaxes += taxPayer.Tax();
            }
            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $ " + totalPaidTaxes.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
