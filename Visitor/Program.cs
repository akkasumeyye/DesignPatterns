using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor // ziyaretci tasarım deseni, genel olarak birbirine benzeyen yada hiyerarşik yapıdaki nesnelerin bri üzerinden diğerlerinin çağrılması..
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager sumeyye= new Manager { Name="Sumeyye", Salary= 1000};
            Manager ahmet= new Manager { Name="Ahmet", Salary= 2000};

            Worker seyda= new Worker { Name="Seyda" , Salary=100};
            Worker burcu= new Worker { Name="Burcu" , Salary=800};

            sumeyye.Subordinates.Add(ahmet);
            ahmet.Subordinates.Add(seyda);
            ahmet.Subordinates.Add(burcu);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(sumeyye);
           
            PayrollVisitor payrollVisitor = new PayrollVisitor();
            Payrise payrise = new Payrise();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payrise);

            Console.ReadLine();
        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }

    class Payrise : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary*(decimal)1.2);
        }
    }
}
