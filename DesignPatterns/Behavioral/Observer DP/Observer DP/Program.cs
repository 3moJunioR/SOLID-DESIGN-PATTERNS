namespace Observer_DP
{
    internal class Program
    {
        #region Observer Design Pattern
        //scenario without Observer Design Pattern
        public class newAgency0
        {
          //  private EmailService _email = new EmailService();
          //  private SMSService _sms = new SMSService();
          //  private AppService _app = new AppService();
          //
          //  public void publishNews(string news)
          //  {
          //      _app.Notify(news);
          //      _email.Notify(news);
          //      _sms.Notify(news);
          //      //if we want to add another service,
          //      //we need to modify this class and add the new service here,
          //      //which violates the Open/Closed Principle
          //
          //  }
        }

        //scenario with Observer Design Pattern

        public interface IObserver
        {
            void Update(string news);
        }
        public interface ISubject
        {
            void Subscribe(IObserver observer);
            void Unsubscribe(IObserver observer);
            void Notify(string news);
        }
        //concrete subject
        public class  NewAgency:ISubject
        {
            private List<IObserver> _observer = new List<IObserver>();
            public void Subscribe(IObserver observer) => _observer.Add(observer);
            public void Unsubscribe(IObserver observer) => _observer.Remove(observer);
            public void Notify(string news)
            {
                foreach (var observer in _observer) { observer.Update(news); }
            }
            public void publishNews(string news)
            {
                Console.WriteLine($"Breaking news: {news}");
                Notify(news);
            }

        }

        //concrete observers
        public class EmailSubscriber : IObserver
        {
            private string _email;
            public EmailSubscriber(string email) => _email = email;
            
            public void Update(string news)
            {
                Console.WriteLine($"Email sent to {_email}: {news}");
            }

        }
        public class SMSSubscriber : IObserver
        {
            private string _phone;
            public SMSSubscriber(string phone) => _phone = phone;
            
            public void Update(string news)
            {
                Console.WriteLine($"SMS sent to {_phone}: {news}");
            }

        }



        #endregion
        static void Main(string[] args)
        {
            //usage
            var agency=new NewAgency();

            var email = new EmailSubscriber("3mo@mail.com");
            var sms = new SMSSubscriber("05451410");

            agency.Subscribe(email);
            agency.Subscribe(sms);

            agency.publishNews("Observer Design Pattern in C#");
            //Email to 3mo@mail.com: Observer Design Pattern in C#
            //SMS to 05451410: Observer Design Pattern in C#

            agency.Unsubscribe(email);
            agency.publishNews("3moJohnny is Depressed");
            //SMS to 05451410: 3moJohnny is Depressed
            // email مش جاله حاجة لأنه عمل unsubscribe

        }
    }
}
