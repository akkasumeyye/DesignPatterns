using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class Program
    {
        private static CustomerManager _customerManager;
        static void Main(string[] args)
        {
            var customer = CustomerManager.CreateAsSingleton(); //new leyerek erişemeyiz, kesinlikle ve kesinlikle bir kez oluşturabiliriz.
            customer.Save();

            Console.ReadLine();
        }

        class CustomerManager
        {
            private CustomerManager()
            {

            }

            public static CustomerManager CreateAsSingleton()
            {
                return _customerManager ?? (_customerManager= new CustomerManager());
            }

            public void Save()
            {
                Console.WriteLine("Saved!");
            }
        }
    }
}
