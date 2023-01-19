using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class Program // arka arkaya işlemler sonucunda bir nesne çıkarmak için kullanılır, if yazmayı engelliyoruz. business katmanında genellikle
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);


            Console.ReadLine();
        }
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }
    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDicount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        public override void ApplyDicount()
        {
            model.DiscountedPrice = model.UnitPrice *(decimal) 0.90;
            model.DiscountApplied = true;
        }

        ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Bavarage";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        public override void ApplyDicount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }
        ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Bavarage";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDicount();
        }
    }
}
