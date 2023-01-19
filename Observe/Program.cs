using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observe
{
    internal class Program // kendisine abone olan sistemlerin bir işlem oldugunda aktif olan, ürün fiyatı düstügünde haberdar etmek gibi
    {
        static void Main(string[] args)
        {
            var customerObserver = new CustomerObserver();
            ProductManager productManager= new ProductManager();
            productManager.Attach(customerObserver);
            productManager.Attach(new EmployeeObserver());
            productManager.Detach(customerObserver);
            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        List<Observer> _observes = new List<Observer>();
        public void UpdatePrice ()
        {
            Console.WriteLine("Product price changed!");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observes.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observes.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observes)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer : Product price changed!");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee : Product price changed!");
        }
    }
}
