namespace Facade
{
    internal class Program
    {
        public class TV
        { 
        public  void TurnOn()=> Console.WriteLine("TV is turned on");
        public  void TurnOff()=> Console.WriteLine("TV is turned off");
        }
        public class soundSys
        {
            public void setVol(int vol)=> Console.WriteLine($"Volume is set to {vol}");
        }
        public class streamingServince
        {
            public void connect(string service)=> Console.WriteLine($"Connected to {service}");
            public void play(string movie)=> Console.WriteLine($"Playing {movie}");
        }
        public class  smartLights
        {
            public void dim(int level)=> Console.WriteLine($"Lights dimmed to {level}%");   

        }
        // Facade class
        public class HeomeTheaterFacade
        {
            private TV _tv;
            private soundSys _sound;
            private streamingServince _streaming;
            private smartLights _lights;

            public HeomeTheaterFacade()
            {
                _tv = new TV();
                _sound = new soundSys();
                _streaming = new streamingServince();
                _lights = new smartLights();
            }
            public void WatchMovie(string title)
            {
                Console.WriteLine("Setting up home theater...");
                _tv.TurnOn();
                _sound.setVol(20);
                _streaming.connect("EgyBest");
                _streaming.play(title);
                _lights.dim(30);
            }
            public void endMovie()
            {
                Console.WriteLine("Shutting down home theater...");
                _tv.TurnOff();
            }
        }
        static void Main(string[] args)
        {
            var homeTheater = new HeomeTheaterFacade();
            homeTheater.WatchMovie("the immortal man");
        }
    }
}
