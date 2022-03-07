namespace CoreIOC.Model
{
    public abstract class Phone
    {
        public virtual void Work()
        {

        }

        public virtual string PhoneType()
        {
            return "";
        }
    }

    public class Honor : Phone
    {
        public override void Work()
        {
            System.Console.WriteLine("荣耀");
        }
    }

    public class Mi : Phone
    {
        public override void Work()
        {
            System.Console.WriteLine("小米");
        }
    }

    public class Vivo : Phone
    {
        public override void Work()
        {
            System.Console.WriteLine("vivo");
        }
    }

}
