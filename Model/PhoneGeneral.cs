using System;
using System.Reflection;

namespace CoreIOC.Model
{
    public class PhoneGeneric
    {
        public void PlayGenericPhone<T>(T phone) where T : Phone
        {
            System.Console.WriteLine($"用{phone.GetType().Name}");
            phone.Work();
        }

        public static Phone CreateInstance()
        {
            Assembly assembly = Assembly.LoadFrom(""); //DLL 名称
            Type type = assembly.GetType(""); // 类型全名称
            return (Phone)Activator.CreateInstance(type);
        }
    }
}
