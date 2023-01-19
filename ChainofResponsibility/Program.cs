using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainofResponsibility // belli sarta gore bizim devreye hangi nesneyi koyacagımızı gosteririz. nesneler hıyerarsık olmalı. sırkette harcamalar 100tl ise mudur onaylar bın lıraysa baskan onunda ustu genel mudur
{
    internal class Program // EVRAK TAKİP İŞLEMLERİ
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense = new Expense { Detail="Training", Amount=98};
            manager.HandleExpense(expense);

            Console.ReadLine();
            
        }
    }

    class Expense
    {
        public  string Detail { get; set; }
        public decimal Amount{ get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpense(Expense expense);

        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount<=100)
            {
                Console.WriteLine("Manager handled the expense!");
            } else if (Successor!=null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }

    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount<=100)
            {
                Console.WriteLine("Vice President handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }

    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense!");
            }
        }
    }
}
