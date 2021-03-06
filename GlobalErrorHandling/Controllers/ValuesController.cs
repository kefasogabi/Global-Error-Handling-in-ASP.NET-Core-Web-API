using System;
using System.Collections.Generic;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILoggerManager _logger;
        public ValuesController(ILoggerManager logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInfo("Fetching all students from the storage");

            var students = DataManager.GetAllStudents();

            throw new Exception("Exception while fetching all students from the storage");

            _logger.LogInfo($"Returning {students.Count} students");

            return Ok(students);
        }
    }
}