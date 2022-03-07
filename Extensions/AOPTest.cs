using Castle.DynamicProxy;
using System.Linq;

namespace CoreIOC.Extensions
{
    public class AOPTest : IInterceptor
    {
        /// <summary>
        /// 查看更多 https://docs.autofac.org/en/latest/advanced/interceptors.html
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            System.Diagnostics.Debug.WriteLine("你正在调用方法 \"{0}\"  参数是 {1}... ",
               invocation.Method.Name,
               string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));
              
            invocation.Proceed(); //在被拦截的方法执行完毕后 继续执行         

            System.Diagnostics.Debug.WriteLine("方法执行完毕，返回结果：{0}", invocation.ReturnValue);
        }

    }
}
