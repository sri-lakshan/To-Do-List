using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecast cursor = new WeatherForecast();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            string queryResult = cursor.getData();
            var tasks = queryResult.Split(',').Select(task => task.Trim()).ToArray();

            return Ok(tasks);  
          
        }

        [HttpPost("mark-as-done")]
        public IActionResult MarkAsDone([FromBody] string task)
        {
            cursor.deleteData(task);
            return Ok();
            
        }

        [HttpPost("add-task")]
        public IActionResult addTask([FromBody] string task)
        {
            cursor.insertData(task);
            return Ok();

        }
    }
}
