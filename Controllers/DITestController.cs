using CoreIOC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreIOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DITestController : ControllerBase
    {
        private readonly ITestService _testService;
        public DITestController(ITestService testService)
        {
            _testService = testService;
        }

        /// <summary>
        /// 作用域生命周期
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetLifeCycle")]
        public string GetLifeCycle([FromServices] ITestService testService2)
        {
            return $"作用域1：{_testService.MyProperty.ToString()}\r\n作用域2：{testService2.MyProperty.ToString()}";
        }

    }
}
