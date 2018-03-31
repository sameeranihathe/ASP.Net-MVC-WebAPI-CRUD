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
            if (id == 0)
            {
                return View(new mvcEmployeeModel());

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Employee/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcEmployeeModel>().Result);
            }

        }
        [HttpPost]
        public ActionResult AddorEdit(mvcEmployeeModel emp)
        {
            if (emp.EmployeeID ==0)
            {
                 HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Employee", emp).Result;
                 TempData["SuccessMessage"] = "Saved Successfully";
                 
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Employee/"+emp.EmployeeID, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");

        }
    }
}