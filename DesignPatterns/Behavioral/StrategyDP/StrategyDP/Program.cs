namespace StrategyDP
{
    internal class Program
    {
        #region Strategy Design Pattern
        //scenario without strategy design pattern
        public class OrderService0
        {
            public void checkout(string paymentType)
            {
                if(paymentType=="Visa")
                    Console.WriteLine("Paying with Visa");
                else if(paymentType=="Vodafone")
                    Console.WriteLine("Paying with VFCash");
                else if(paymentType=="Cash")
                    Console.WriteLine("Cash on Delivery");
                // كل ما تيجي طريقة جديدة هتفتح الكلاس وتعدل و دا بيخالف مبدأ Open/Closed Principle
                //
            }

        }
        //scenario with strategy design pattern
        public interface IPaymentStrategy
        {
            void Pay(double amount);
        }
        //concrete Strategies
        public class VisaStrategy:IPaymentStrategy
        {
            public void Pay(double amount)=>
                Console.WriteLine($"Paying {amount} EGP  with Visa");
        }
        public class  VodafoneStrategy:IPaymentStrategy
        {
            public void Pay(double amount)=> Console.WriteLine($"Paying {amount} EGP  with Vodafone Cash");
        }
        public class CashStrategy : IPaymentStrategy
        {
            public void Pay(double amount) =>
                Console.WriteLine($"Paid {amount} EGP cash on delivery.");
        }
        // Context
        public class OrderService
        {
            private IPaymentStrategy _paymentStrategy;
            public void SetPaymentStrategy(IPaymentStrategy strategy)
            {
                _paymentStrategy = strategy;
            }
            public void checkout(double amount)
            {
                _paymentStrategy.Pay(amount);
            }
        }


        #endregion
        static void Main(string[] args)
        {
            //usage
            var order = new OrderService();
            order.SetPaymentStrategy(new VisaStrategy());
            order.checkout(500);
            // Paid 500 EGP with Visa
            order.SetPaymentStrategy(new VodafoneStrategy());
            order.checkout(300);
            // Paid 300 EGP with Vodafone Cash
            //and so on without modifying the OrderService class
        }
    }
}
