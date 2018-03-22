using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Program
    {
        public static void Main()
        {
            var documents = new string[]
            {
                "Doc1", "Doc2", "Doc3"
            };

            var employees = new List<Employee>()
            {
                new Manager("Gosho", documents),
                new Employee("Maria")
            };

            var printer = new DetailsPrinter(employees);

            printer.PrintDetails();
        }
    }
}
