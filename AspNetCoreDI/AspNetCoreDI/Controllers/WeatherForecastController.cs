using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly SomeClass someClass;

        public WeatherForecastController(SomeClass someClass)
        {
            this.someClass = someClass;
        }

        [HttpGet]
        public string Get()
        {
            return this.someClass.GetOutput();
        }
    }
    public class SomeClass
    {
        public string GetOutput()
        {
            return "Hello World";
        }
    }
}
