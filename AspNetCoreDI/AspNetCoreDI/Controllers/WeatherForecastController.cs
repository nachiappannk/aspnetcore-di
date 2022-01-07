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
        private readonly ILogger logger;

        public SomeClass(ILogger<SomeClass> logger)
        {
            this.logger = logger;
        }
        public string GetOutput()
        {
            logger.LogInformation("Some class get output called");
            return "SomeClass :" + this.GetHashCode() + "\t\t"; 
        }
    }

    public class SomeOtherClass 
    {
        private readonly SomeClass someclass;
        private readonly ILogger<SomeOtherClass> logger;

        public SomeOtherClass(SomeClass someclass, int intValue, ILogger<SomeOtherClass> logger)
        {
            this.someclass = someclass;
            this.logger = logger;
        }
        public string GetOutput()
        {
            logger.LogInformation("Some other class output called");
            return "SomeOtherClass :" + this.GetHashCode() + "(inside)"+ someclass.GetOutput()+ "\t\t";
        }
    }
}
