using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using usergate2.Models;
using System.Net;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace usergate2.Controllers
{
    public class CustomerController : Controller
    {
        IEnumerable<Sex> sex = new List<Sex>{
            new Sex{Id = 1, Name="Мужской"},
            new Sex{Id = 2, Name="Женский"}
        };



        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {

            
            ViewBag.Sex = new SelectList(sex, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            // Create a request using a URL that can receive a post.
            WebRequest request = WebRequest.Create("http://localhost:5000/Customer/Test/");
            // Set the Method property of the request to POST.
            request.Method = "POST";

            // Create POST data and convert it to a byte array.
            string postData = customer.ToString();
            Console.WriteLine(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();

            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                return View();

                //return "Thanks " + customer.Name;
            }
        }

        [HttpPost]
        public string Test(Customer cust)
        {
           // System.Diagnostics.Debug.WriteLine(sName);
            return "Спасибо за регистрацию " + cust.Name + " с полом " + cust.Sex;
        }
    }
}