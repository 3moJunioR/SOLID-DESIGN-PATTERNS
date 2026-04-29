using static SOLID.Program;

namespace SOLID
{

    internal class Program
    {
        #region SRP - Single Responsibility Principle
        internal class Employee1
        {
            public string Name { get; set; }
            public double Salary { get; set; }

            //Violates SRP
            public double clacSalary()
            {
                return Salary * 1.1;
            }
            public void saveToDb()
            {
                Console.WriteLine($"Saving {Name} to database.....");
            }
            public void printReport()
            {
                Console.WriteLine($"Employee: {Name}, Salary: {Salary}");
            }

        }
        //Follows SRP
        internal class Employee
        {
            public string Name { get; set; }
            public double Salary { get; set; }
            public  double calcSalary()
            {
                return Salary*1.1;
            }
        }
        internal class EmpRepository
        { 
            public void SaveToDb(Employee emp)
            {
                Console.WriteLine($"Saving {emp.Name} to database.....");
            }
        }
        internal class EmpReport
        {
            public void PrintReport(Employee emp)
            {
                Console.WriteLine($"Employee: {emp.Name}, Salary: {emp.Salary}");
            }
        }
        #endregion

        #region OCP - Open/Closed Principle
        //Violates OCP
        public class discountCalc
        {
            public double Calculate(string customerType , double price)
            {
                if (customerType == "Regular")
                    return price * 0.9;
                else if (customerType == "VIP")
                    return price * 0.5;
                // كل ما يجي نوع جديد، هتفتح الكلاس وتعدل فيه!
            }
        }
        //Follows OCP
        public abstract class discount
        {
            public abstract double Calculate(double  price);
        }
        public class RegularDiscount:discount
        {
            public override double Calculate(double price) => price * 0.9;
        }
        public class VIPdiscount : discount
        {
            public override double Calculate(double price) => price * 0.5;
        }
        // عايز نوع جديد؟ بس تضيف كلاس جديد من غير ما تلمس الكود القديم!
        public class PlatinumDiscount : discount
        {
            public override double Calculate(double price) => price * 0.7;
        }
        #endregion

        #region LSP - Liskov Substitution Principle
        //Violates LSP
        public class Bird0
        {
            public virtual void Fly() => Console.WriteLine("I can Fly");
        }
        public class Penguin :Bird0
        {
                       public override void Fly() => throw new Exception("I can't Fly");
        }
        // المشكلة هنا
        //Bird bird = new Penguin();
        // bird.Fly(); //Exception

        //Follows LSP
        public abstract class  Bird()
        {
            public abstract void Move();
        }
        public class  flyingBird : Bird
        {
            public override void Move()=> Console.WriteLine("I can Fly");
        }
        public class Punguin : Bird
        { 
            public override void Move()=> Console.WriteLine("I can Swim");
        }

        // دلوقتي
        //Bird bird = new Penguin();
        //bird.Move(); شغال زي الفل ك صب  كلاس بيحل محل الكلاس البيرنت عادي




        #endregion

        #region ISP - Interface Segregation Principle
        // Violates ISP
        public interface IWorker0
        {
            void Eat();
            void Work();
            void Sleep();
        }
        public class Robot0 : IWorker
        { 
          public void Work()=> Console.WriteLine("im working");
          public void Eat() => throw new Exception("Robot don't eat"); // المشكلة هنا
          public void Sleep()=> throw new Exception("Robot don't sleep"); // المشكلة هنا برده

        }
        //طيب المشكلة ايه؟
        // انك لما تيجي تستخدم الروبوت هتضطر تكتب كود عشان تتعامل مع الاكسبشن اللي بيطلع من الاكل والنوم، مع ان الروبوت اصلا ولا بياكل ولا بينام

        //Follows ISP
        public interface IWorker
        { void Work(); }
        public interface IEatable
        { void Eat(); }
        public interface ISleepable
        { void Sleep(); }
        public class Human : IWorker, IEatable, ISleepable
        { 
            public void Work()=> Console.WriteLine("im working");
            public void Eat()=> Console.WriteLine("im eating");
            public void Sleep()=> Console.WriteLine("im sleeping");
        }
        public class Robot: IWorker
        {
            public void Work() => Console.WriteLine("im working"); // اللي يخصه بس
        }
        #endregion


        static void Main(string[] args)
        {
            
        }
    }
}
