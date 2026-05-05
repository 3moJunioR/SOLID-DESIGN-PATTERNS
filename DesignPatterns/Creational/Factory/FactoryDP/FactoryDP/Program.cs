namespace FactoryDP
{
    internal class Program
    {
        #region
        //scenario with no factory pattern:
        //لو مثلا عندي types مختلفه من النوتفكيشنز
        //  public class EmailNotification0
        //  {
        //      public void Send(string message)=> Console.WriteLine("Email sent: " + message);
        //  }
        //  var type = "Email";
        //  if(type=="Email")
        //      new EmailNotification0().Send("Hla");
        //  else if(Type=="SMS")
        //      new SMSNotification0().Send("Hla");
        //  else if(type=="Push")
        //      new PushNotification0().Send("Hla");
        //هنا لو عايز اضيف نوع جديد من النوتفكيشنز هضطر اعدل الكود ده وهضيف شرط جديد وهكذا
        //و دا بيخالف مبدأ ال الاوبن كلوز في السوليد + الكود بعدين هيبقي صعب التعديل او اني اصلح فيه حاجة ضاربه

        //with factory pattern:
        public class EmailNotification
        {
            public interface INotification
            { public void Send(string message); }

            // الكونكريت كلاسز اللي هتطبق الانترفيس
            public class EmailNotification: INotification
            {
             public void Send(string message) => Console.WriteLine( $"Email: {message}");
            }
            public class SMSNotification: INotification
            {
             public void Send(string message) => Console.WriteLine( $"SMS: {message}");
            }
            public class PushNotification: INotification
            {
             public void Send(string message) => Console.WriteLine( $"Push: {message}");
            }


            //الفاكتوري كلاس اللي هتحدد نوع النوتفكيشن اللي عايزها
            public class NotiFactory
            {
                public static INotification Create(string type)
                {
                    return type switch
                    {
                        "Email" => new EmailNotification(),
                        "SMS" => new SMSNotification(),
                        "Push" => new PushNotification(),
                        _ => throw new Exception("Unknown type")
                    };
                }
            }
            //Usage:
            //var notification = NotiFactory.Create("Email");
            //notification.Send("Hla");

            //عاوز sms!!!
            //var sms=NotiFactory.Create("SMS");
            //sms.Send("Hla");

        }


        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
