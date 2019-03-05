/**
 * The policy class.
 * To make it thread-safe and lazy loading, 
 * it uses the double-checked locking from page 184 of the Head First Design Patterns book.
 * 
 * */
using System;
using System.Collections.Generic;

namespace CS3450_Program05_JNP
{
    public class Policy
    {
        private volatile static Policy uniqueInstance;
        private static readonly object getInstanceLock = new object();
        private List<PolicyHolder> policyHolders;

        private Policy()
        {
            policyHolders = new List<PolicyHolder>();
        }

        public static Policy GetInstance() {
            if (uniqueInstance == null)
            {
                lock (getInstanceLock)
                {
                    uniqueInstance = new Policy();
                }
            }
            return uniqueInstance;
        }

        // return the names and ids in a string
        // the policy holders themselves stay tucked away in the policy singleton
        public List<string> GetPolicyHolders()
        {
            return new List<string>(policyHolders.ConvertAll(new Converter<PolicyHolder, string>(policyHolder => $"Name: {policyHolder.name} ID: {policyHolder.id}")));
        }

        public void SetNewPolicyHolder(string policyHolder)
        {
            string n = policyHolder.Split(':')[1];
            int i = int.Parse(policyHolder.Split(':')[0]);
            policyHolders.Add(new PolicyHolder(n,i));
        }

        public string GetDescription()
        {
            return "POLICY CLASS: This contains the unique list of the names and id numbers of the policy holders";
        }

        private struct PolicyHolder
        {
            public string name;
            public int id;

            public PolicyHolder(string n, int i)
            {
                name = n;
                id = i;
            }

        }

    }
}
