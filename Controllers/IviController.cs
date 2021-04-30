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
using System.Text.Json;
using Newtonsoft.Json;
using System.Security.Cryptography;


namespace usergate2.Controllers
{
    public class IviController : Controller
    {

public IActionResult Index()
        {
            return View();
        }

        public IActionResult Abonent(int id)
        {
            Console.WriteLine($"Мы получаем id = {id}");
            
            byte[] hash = Encoding.ASCII.GetBytes($"service_ext,{id},brtS9$P9_W");
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string sign = "";
            foreach (var b in hashenc)
            {
            sign += b.ToString("x2");
            }
            Console.WriteLine(sign);

            // Create a request using a URL that can receive a post.
            WebRequest request = WebRequest.Create($"http://test-partner.demo.platform-api.dev.enaza.ru/api/subscription/getShippingData?userId={id}&productCode=service_ext&sign={sign}");

//sign=eb96e3e791b7d9f2104a6ca7bdca0a10

            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.



                Console.WriteLine(responseFromServer);
            
                ApiResponses responses = new ApiResponses();
                
                responses.getShippingData = JsonConvert.DeserializeObject<getShippingData>(responseFromServer);
                //Console.WriteLine(responses.getShippingData.distrList[0].key);
               // Console.WriteLine(responses.getShippingData.keyList[0].name);
               // Console.WriteLine(responses.getShippingData.distrList[1]);

                return View(responses);
            }
              

                //return "Thanks " + customer.Name;
            }

        }
    }
