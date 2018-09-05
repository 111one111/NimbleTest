using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmploymentTestLibrary;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentTestWeb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ILogic _logic;

        public ValuesController(ILogic logic)
        {
            _logic = logic;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {           
            var result =_logic.EmploymentTest(null);
            return Ok(result);
        }      
    }
}
