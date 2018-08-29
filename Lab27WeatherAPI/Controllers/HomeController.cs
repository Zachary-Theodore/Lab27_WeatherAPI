using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lab27WeatherAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //making a request
            HttpWebRequest apiRequest =
            WebRequest.CreateHttp("https://forecast.weather.gov/MapClick.php?lat=36.746841&lon=-119.772591&FcstType=json");

            apiRequest.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";

            //response
            HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();
            if (apiResponse.StatusCode == HttpStatusCode.OK)//if we got status == 200
            {
                    //get data and then parse it
                    StreamReader responseData = new StreamReader(apiResponse.GetResponseStream());

                    string weather = responseData.ReadToEnd();// reads the data from the response
                                                              //todo parse the json data
                    JObject jsonWeather = JObject.Parse(weather);



                ViewBag.location = jsonWeather["location"]["areaDescription"];
                    ViewBag.weather = jsonWeather["data"]["text"];
                ViewBag.weatherPic = jsonWeather["data"]["iconLink"];



            }

            //











            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}