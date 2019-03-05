using System;
using System.IO;

namespace CS3450_Program05_JNP
{
    class InsuranceDriver
    {
        Policy policy;

        public InsuranceDriver()
        {
            policy = Policy.GetInstance();
        }

        public void HandlePolicies()
        {
            Console.WriteLine("\nSetting names and ids from PolicyHolders.txt:");
            try
            {
                foreach (string policyHolder in File.ReadAllLines("PolicyHolders.txt"))
                {
                    policy.SetNewPolicyHolder(policyHolder);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("PolicyHolders.txt file not found.");
            }
        }

        public void PrintPolicies()
        {
            Console.WriteLine("\nPrinting the policy holders from the policy singleton:");
            policy.GetPolicyHolders().ForEach(policyHolder => Console.WriteLine(policyHolder));
        }

        public void PrintDescription()
        {
            Console.WriteLine("\nPrinting the description from the policy singleton:");
            Console.WriteLine(policy.GetDescription());
        }

    }
}
