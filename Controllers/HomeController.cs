using DERrestaurant3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DERrestaurant3.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<MenuItem> list = new List<MenuItem>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = DERrestaurant3.Properties.Resources.ConnectionString;
        }


        public IActionResult Location()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Drinks()
        {
            FetchDrinks();
            return View(list);
        }
        public IActionResult Appetizer()
        {
            FetchData();
            return View(list);
        }
        public IActionResult Lunch()
        {
            FetchData();
            return View(list);
        }
        public IActionResult Breakfast()
        {
            FetchBreakfast();
            return View(list);
        }
        public IActionResult Dinner()
        {
            FetchData();
            return View(list);
        }
        //
        public void FetchData()
        {
            if (list.Count > 0)
            {
                list.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP(1000) [Image],[MenuItemId] ,[ItemName],[Description],[Price] FROM [DERrestaurant].[dbo].[MenuItem]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new MenuItem()
                    {
                        Image = dr["Image"].ToString(),
                        MenuItemId = dr["MenuItemId"].ToString(),
                        ItemName = dr["ItemName"].ToString(),
                        Description = dr["Description"].ToString(),
                        Price = dr["Price"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //
        public void FetchBreakfast()
        {
            if (list.Count > 0)
            {
                list.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP(1000) [Image],[MenuItemId] ,[ItemName],[Description],[Price] FROM [DERrestaurant].[dbo].[Breakfast1]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new MenuItem()
                    {
                        Image = dr["Image"].ToString(),
                        MenuItemId = dr["MenuItemId"].ToString(),
                        ItemName = dr["ItemName"].ToString(),
                        Description = dr["Description"].ToString(),
                        Price = dr["Price"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void FetchDrinks()
        {
            if (list.Count > 0)
            {
                list.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP(1000) [Image],[MenuItemId] ,[ItemName],[Description],[Price] FROM [DERrestaurant].[dbo].[Drinks]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new MenuItem()
                    {
                        Image = dr["Image"].ToString(),
                        MenuItemId = dr["MenuItemId"].ToString(),
                        ItemName = dr["ItemName"].ToString(),
                        Description = dr["Description"].ToString(),
                        Price = dr["Price"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
