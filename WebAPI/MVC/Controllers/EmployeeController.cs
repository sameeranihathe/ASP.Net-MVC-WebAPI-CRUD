using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployeeModel> empList;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Employee").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            
            return View(empList);
        }
        [HttpGet]
        public ActionResult AddorEdit(int id=0)
        {
            return View(new mvcEmployeeModel());
        }
        [HttpPost]
        public ActionResult AddorEdit()
        {
            return View();
        }
    }
}