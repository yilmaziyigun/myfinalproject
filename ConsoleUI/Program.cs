﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");
            ProductTest();
            //CategoryTest();
            Console.WriteLine("test2");
            Console.ReadLine();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName+" - "+product.CategoryName);
            }
        }
    }
}
