using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateCar([FromBody] CarRequest carRequest)
        {

            try
            {
                string filePath = @"C:\Users\Matthieu\source\repos\CarAPI\CarAPI\JsonData\Car.json";

                // serialize JSON to a string and then write string to a file
                System.IO.File.WriteAllText(filePath, JsonConvert.SerializeObject(carRequest));

                // serialize JSON directly to a file
                using (StreamWriter file = System.IO.File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, carRequest);
                }

                return Ok("car created");
            }
            catch (Exception ex) when (ex != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
