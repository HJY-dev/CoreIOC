using CoreIOC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreIOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoDIController : ControllerBase
    {

        private readonly ITestService _testService;
        public ITestService _testService2 { get; set; }

        public AutoDIController(ITestService testService)
        {
            _testService = testService;
        }

        /// <summary>
        /// Auto属性注入
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetPersonListByAttribute")]
        public List<string> GetPersonList()
        {
            return _testService2.GetList("");
        }

        /// <summary>
        /// Auto构造注入
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetPersonListByStructure")]
        public List<string> GetPersonListByStructure()
        {
            return _testService.GetList("");
        }
    }
}
