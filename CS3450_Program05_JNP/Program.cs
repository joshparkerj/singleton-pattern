/**
* Project Prolog
* Name: Josh Parker
* CS3450 Section 002
* Project: Program 5 - Singleton Program
* Date: 03/04/2019 11:06 PM
* Disclaimer: This is my own work, not that of others.
* Purpose: An insurance program with a singleton policy class.
* The policy class is thread safe and uses lazy loading.
* Restricts the creation/access of customer policies by restricting
* the instantiation of the class to one object.
*/
using System;

namespace CS3450_Program05_JNP
{
    class Program
    {
        static void Main(string[] args)
        {
            InsuranceDriver driver = new InsuranceDriver();
            driver.HandlePolicies();
            driver.PrintPolicies();
            driver.PrintDescription();
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }

    }
}
