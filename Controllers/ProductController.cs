using CoffeeShopProductListLab.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CoffeeShopProductListLab.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var db = new MySqlConnection("Server=127.0.0.1;Database=coffeeshopproductlist;Uid=root;Pwd=QuickenROcketMortgage1111!");
            List<Product> prods = db.GetAll<Product>().ToList();
            return View(prods);

        }

        public IActionResult Category()
        {
            var db = new MySqlConnection("Server=127.0.0.1;Database=coffeeshopproductlist;Uid=root;Pwd=QuickenROcketMortgage1111!");
            //Gets a list of just the categories 
            List<Product> categories = db.Query<Product>($"select distinct category from product").ToList();
            return View(categories);
        }

        public IActionResult CategoryDetails(string id)
        {
            var db = new MySqlConnection("Server=127.0.0.1;Database=coffeeshopproductlist;Uid=root;Pwd=QuickenROcketMortgage1111!");
            Product categoryNeeded = db.Get<Product>(id);

            var category = db.Query<Product>($"Select * from product where id = '{id}'").ToList();
            ViewData["category"] = category; 
            return View(categoryNeeded);  
        }

        public IActionResult Detail(int id)
        {
            var db = new MySqlConnection("Server=127.0.0.1;Database=coffeeshopproductlist;Uid=root;Pwd=QuickenROcketMortgage1111!");
            Product productReview = db.Get<Product>(id);

            var prods = db.Query<Product>($"select * from product where id = '{id}'").ToList();
            ViewData["product"] = prods;
            return View(productReview); 
        }



    }
}
