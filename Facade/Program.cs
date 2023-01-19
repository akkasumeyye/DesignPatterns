using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Program  // elimizde çeşitli sınıflar var ve bu sınıfları her seferinde ortak amac için kullanıyoruzdur, tek tek kullanmak yerine bir cehe olustururuz
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged!");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
      

        public void Cache()
        {
            Console.WriteLine("Cached!");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked!");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated checked!");
        }
    }

    internal interface IValidate
    {
        void Validate();
    }

    class CustomerManager 
    {

        private CrossCuttongConcernsFacade _concerns;
        public CustomerManager()
        {
          _concerns = new CrossCuttongConcernsFacade();
        }

        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            _concerns.Logging.Log();
            _concerns.Validation.Validate();

            Console.WriteLine("Saved");

        }
    }

    class CrossCuttongConcernsFacade
    {
       public ILogging Logging;
       public ICaching Caching;
       public IAuthorize Authorize;
       public IValidate Validation;
       
      public CrossCuttongConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validation = new Validation();
        }
    }
}
