using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program // kurumlardaki hiyerarşik yapı gibi düşünebiliriz
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee { Name = "Sumeyye Akkas"};
            Employee employee2 = new Employee { Name =  "Seyda Akkas"};

            employee1.AddSubordinate(employee2);

            Employee employee3 = new Employee { Name = "Perihan Akkas" };
            employee1.AddSubordinate(employee3);

            Contractor ali = new Contractor { Name = "Ali" };
            employee3.AddSubordinate(ali);

            Employee employee4 = new Employee { Name = "Ahmet" };
            employee2.AddSubordinate(employee4);

            Console.WriteLine(employee1.Name);

            foreach (Employee manager in employee1)
            {
                Console.WriteLine("   {0}",manager.Name);

                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}",employee.Name);
                }
            }

            Console.ReadLine();
        }
    }
    interface IPerson
    {
         string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
