using static Decorator.Program;

namespace Decorator
{
    internal class Program
    {
        #region Decorator Pattern
        //scenario without decorator pattern

        // public class Coffee { }
        // public class CoffeeWithMilk { }
        // public class CoffeeWithSugar { }
        // public class CoffeeWithMilkAndSugar { }
        // public class CoffeeWithMilkAndSugarAndCream { }
        // كلاس جديد لكل combination

        //scenario with decorator pattern:

        //Base IFace
        public interface ICofee
        {
            string GetDescription();
            double GetPrice();
        }
        //concrete component
        public class SimpleCofee : ICofee
        {
            public string GetDescription() => "Simple Cofee";
            public double GetPrice() => 10.0;
        }
        //Base Decorator
        public abstract class CofeeDecorator : ICofee
        {
            protected ICofee _cofee;
            protected CofeeDecorator(ICofee cofee)
            {
                _cofee = cofee;
            }
            public virtual string GetDescription()=> _cofee.GetDescription();
            public virtual double GetPrice() => _cofee.GetPrice();
        }
        //concrete decorators
        public class MilkDecorator:CofeeDecorator
        {
            public MilkDecorator(ICofee cofee):base(cofee) {}
            public override string GetDescription()=>
                _cofee.GetDescription()+", +Milk";
            public override double GetPrice() => _cofee.GetPrice() + 2.0;

        }
        public class SugarDecorator:CofeeDecorator
        {
            public SugarDecorator(ICofee cofee):base(cofee) { }
            public override string GetDescription() => _cofee.GetDescription() + ", + Sugar";
            public override double GetPrice() => _cofee.GetPrice() + 1.00;
        }
        public class CreamDecorator:CofeeDecorator
        {
            public CreamDecorator(ICofee cofee) : base(cofee) { }
            public override string GetDescription()=> _cofee.GetDescription() + ", + Cream";
            public override double GetPrice() => _cofee.GetPrice() + 5.0;
        }

        //Usage:
        //ICofee cofee=new SimpleCofee();
        //Console.WriteLine($"{coffee.GetDescription()} = {coffee.GetCost()} EGP");
        // Simple Coffee = 10 EGP


        #endregion
        static void Main(string[] args)
        {
            //Usage:
            ICofee cofee = new SimpleCofee();
            cofee = new MilkDecorator(cofee);
            cofee = new SugarDecorator(cofee);
            cofee = new CreamDecorator(cofee);
            Console.WriteLine($"{cofee.GetDescription()} = {cofee.GetPrice()} EGP");
            // Simple Coffee + Milk + Sugar + Cream = 25 EGP 


        }
        // امتى تستخدم Decorator؟

        //لما عايز تضيف features على object من غير ما تعدل فيه
        //لما عندك combinations كتير مش عايز تعمل كلاس لكل واحدة
        //بيطبق الـ Open/Closed Principle بشكل مثالي


    }
}
