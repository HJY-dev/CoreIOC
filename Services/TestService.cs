using Autofac.Extras.DynamicProxy;
using CoreIOC.Extensions;
using System;
using System.Collections.Generic;

namespace CoreIOC.Services
{
    [Intercept(typeof(AOPTest))]
    public class TestService : ITestService
    {
        public TestService()
        {
            MyProperty = Guid.NewGuid();
        }

        public Guid MyProperty { get; set; }

        public List<string> GetList(string a)
        {
            return new List<string>() { "LiLei", "ZhangSan", "LiSi" };
        }
    }
}
