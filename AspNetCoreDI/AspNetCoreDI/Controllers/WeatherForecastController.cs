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
        private readonly SomeOtherClass someOtherClass;

        public WeatherForecastController(SomeClass someClass, SomeOtherClass someOtherClass)
        {
            this.someClass = someClass;
            this.someOtherClass = someOtherClass;
        }

        [HttpGet]
        public string Get()
        {
            return this.someClass.GetOutput() + someOtherClass.GetOutput();
        }
    }
    public class SomeClass
    {
        public string GetOutput()
        {
            return "SomeClass :" + this.GetHashCode() + "\t\t"; 
        }
    }

    public class SomeOtherClass 
    {
        private readonly SomeClass someclass;

        public SomeOtherClass(SomeClass someclass)
        {
            this.someclass = someclass;
        }
        public string GetOutput()
        {
            return "SomeOtherClass :" + this.GetHashCode() + "(inside)"+ someclass.GetOutput()+ "\t\t";
        }
    }
}
