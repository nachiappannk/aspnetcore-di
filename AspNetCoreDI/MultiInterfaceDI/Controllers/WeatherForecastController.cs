using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiInterfaceDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ToolFactory toolFactory;

        public WeatherForecastController(ToolFactory toolFactory)
        {
            this.toolFactory = toolFactory;
        }

        [HttpGet]
        public string Get([FromQuery]string tooltype, [FromQuery] string input)
        {
            var tool = toolFactory.GetTool(tooltype);
            return tool.Process(input);
        }
    }
}
