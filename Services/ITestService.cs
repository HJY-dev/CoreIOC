using System;
using System.Collections.Generic;

namespace CoreIOC.Services
{
    public interface ITestService
    {
        Guid MyProperty { get; }
        List<string> GetList(string a);
    }
}
