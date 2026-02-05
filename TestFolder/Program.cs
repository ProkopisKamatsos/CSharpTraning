using System;
using System.Collections;

namespace GenericsBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Salaries salaries = new Salaries();
            ArrayList salaryList = salaries.GetSalaries();
            float salary = (float)salaryList[1];
            salary = salary +(salary * 0.2f);
                Console.WriteLine("The salary with 20% increase is: " + salary);


        }

        public class Salaries
        {
            ArrayList _salaryList = new ArrayList();
            public Salaries()
            {
                _salaryList.Add(60000.34);
                _salaryList.Add(40000.51f);
                _salaryList.Add(20000.23f);
            }
            public ArrayList GetSalaries()
            {
                return _salaryList;

            }
        }
    }
}