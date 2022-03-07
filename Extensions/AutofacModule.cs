using Autofac;
using Autofac.Extras.DynamicProxy;
using CoreIOC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreIOC.Extensions
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //获取所有控制器类型并使用属性注入
            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                .PropertiesAutowired();

            //注入AOP
            builder.Register(c => new AOPTest());

            //注入测试服务
            builder.RegisterType<TestService>().As<ITestService>()
                .PropertiesAutowired() //开启属性注入
                .EnableInterfaceInterceptors() //开启aop拦截
                .InstancePerLifetimeScope(); //Scope周期

        }
    }
}
