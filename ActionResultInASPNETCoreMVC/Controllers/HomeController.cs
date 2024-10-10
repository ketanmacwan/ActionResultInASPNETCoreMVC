using ActionResultInASPNETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ActionResultInASPNETCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(string Category)
        {
            var options = new JsonSerializerOptions()
            {
                // Property names will remain as defined in the class
                PropertyNamingPolicy = null,

                // JSON will be formatted with indents for readability
                WriteIndented = true,
            };

            try
            {
                //Based on the Category Fetch the Data from the database 
                //Here, we have hard coded the data
                List<Product> products = new List<Product>
                {
                    new Product{ Id = 1001, Name = "Laptop",  Description = "Dell Laptop" },
                    new Product{ Id = 1002, Name = "Desktop", Description = "HP Desktop" },
                    new Product{ Id = 1003, Name = "Mobile", Description = "Apple IPhone" }
                };

                //Please uncomment the following two lines if you want see what happend when exception occurred
                //int a = 10, b = 0;
                //int c = a / b;
                return Json(products, options);
            }
            catch (Exception ex)
            {
                var errorObject = new
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    ExceptionType = "Internal Server Error"
                };

                return new JsonResult(errorObject, options)
                {
                    StatusCode = StatusCodes.Status500InternalServerError // Status code here 
                };
            }
        }
    }
}