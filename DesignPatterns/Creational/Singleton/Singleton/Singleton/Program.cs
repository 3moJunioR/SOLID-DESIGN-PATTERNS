namespace Singleton
{
    internal class Program
    {
        #region
        //Violates Singleton

        public class dbConnection0
        {
            public dbConnection0()
            {
                Console.WriteLine("new Connection created");
            }
        }
        //the problem => كل مرة بتعمل object جديد = resources ضايعة 

        //var db1 = new dbConnection0(); اول كونكشن
        //var db2= new dbConnection0(); كونكشن جديد
        //var db3 = new DatabaseConnection();  تالت واحد  etc...

        //-------------------------------------------------------------

        //Singleton Pattern
        public class dbConnection
        {
            private static dbConnection _instance;
            private dbConnection() //خد بالك, برايفت عشان محدش يأكسسها من برا ب new
            {
                Console.WriteLine("Connection created");   
            }
            public static dbConnection GetInstance()
            {
                if (_instance==null)
                    _instance=new dbConnection();
                return _instance;
            }
            public void Query(string sql)
            {
                 Console.WriteLine($"Executing query: {sql}");
            }
            //the true usage:
            //var db1 = dbConnection.GetInstance(); اول كونكشن
            //var db2= dbConnection.GetInstance(); نفس الكونكشن
            // Console.WriteLine(db1 == db2); // True نفس الأوبجكت 
        }
        //another scenario: thread safety
        public class dbconnection
        {
            private static readonly object _lock = new object();
            private static dbconnection _instance;

            private dbconnection() {}
            public static dbconnection getInstance()
            {
                if(_instance==null)
                { 
                    lock(_lock) //لو فيه أكتر من ثريد بيحاولوا يعملوا انستانس في نفس الوقت, هتعمل لوك عشان تمنعهم من الدخول في نفس الوقت
                        {
                            if(_instance==null) //تاني تشيك عشان لو واحد دخل وعمل انستانس, التاني يلاقيه موجود
                            {
                               _instance=new dbconnection();
                            }
                        }
                    }
                return _instance;
            }
        }


        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
