namespace Adapter
{
    internal class Program
    {
        #region
        //scenario with no Adapter
        public class oldPaymentSys0
        {
            public void pay(string amount)
            {
                Console.WriteLine($"old Sys Pay{amount}");
            }
        }
        //نفرض دلوقتي عندي انترفيس جديد
        public interface newPaymentSys
        {
            void processpay(double amount);
        }
        //المشكلة هنا ايه بقي؟
        // مش هقدر استخدم ال oldPaymentSys0 مع ال newPaymentSys لانهم مش متوافقين مع بعض

        //scenario with Adapter
        public class oldPaySys {
            public void pay(string amount)
            {
                Console.WriteLine($"old Sys Pay{amount}");
            }
        }
        //new Interface
        public interface INewPaySys
        {
            void processpay(double amount);
        }
        //Adapter
        public class paymentAdapter : INewPaySys
        {
            private oldPaySys _oldsys;
            public paymentAdapter(oldPaySys oldsys)
            {
                _oldsys = oldsys;
            }
            public void processpay(double amount)
            {
                //بيحول الدابل لسترينج عشان يبعته للاولد سيستم
                string convertedAmount=amount.ToString("F2");
                _oldsys.pay(convertedAmount);
            }
        }
        //usage
       // INewPaySys payment=new paymentAdapter(new oldPaySys());
       // payment.processpay(100.50);
        //old sys => paying 100.50


        #endregion
        static void Main(string[] args)
        {
            INewPaySys payment = new paymentAdapter(new oldPaySys());
            payment.processpay(100.50);
        }
    }
}
