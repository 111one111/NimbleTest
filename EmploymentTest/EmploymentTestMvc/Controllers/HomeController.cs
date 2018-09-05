using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmploymentTestLibrary;
using Microsoft.AspNetCore.Mvc;


namespace EmploymentTestMvc.Controllers
{
    public class HomeController : Controller
    {
        ILogic _ilogic;
        public HomeController(ILogic iLogic)
        {
            _ilogic = iLogic;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost("CalculateField")]
        public IActionResult CalculateField(string calculation)
        {
            var result = _ilogic.EmploymentTest(calculation);

            return Ok(result);
        }
    }
}
