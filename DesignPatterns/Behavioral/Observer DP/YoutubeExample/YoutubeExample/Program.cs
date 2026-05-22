using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace YoutubeExample
{
    internal class Program
    {
        //observerIface
        public interface  ISubscriber
        {
            void Update(string ChannelName, string VideoTitle);
        }
        //subjectIface
        public interface IYoutubeChannel
        {
            void Subscribe(ISubscriber subscriber);
            void UnSubscribe(ISubscriber subscriber);
            void Notify(string videoTitle);
            
        }
        //concreteSubject
        public class YoutubeChannel : IYoutubeChannel
        {
            private string _channelName;
            private List<ISubscriber> _subscribers = new List<ISubscriber>();
            public YoutubeChannel(string  channelName)=>_channelName = channelName;
            
            public void Notify(string videoTitle)
            {
                foreach (var subscriber in _subscribers)
                    subscriber.Update(_channelName, videoTitle);
            }


            public void Subscribe(ISubscriber subscriber)
            {
                _subscribers.Add(subscriber);
            }

            public void UnSubscribe(ISubscriber subscriber)
            {
                _subscribers.Remove(subscriber);
            }
            public void UploadVideo(string videoTitle)
            {
                Console.WriteLine($"{_channelName} uploaded a new video: {videoTitle}");
                Notify(videoTitle);
            }
        }

        //concreteObserver
        public class YoutubeUser : ISubscriber
        {
            private string _username;
            public YoutubeUser(string username)
            {
                _username = username;
            }
            public void Update(string ChannelName, string VideoTitle)
            {
                Console.WriteLine($"{_username} got Notified {VideoTitle} from {ChannelName}");
            }
        }

        static void Main(string[] args)
        {
            var channl = new YoutubeChannel("3moJohnny");

            var user1 = new YoutubeUser("Wahba");
            var user2 = new YoutubeUser("Junior");
            var user3 = new YoutubeUser("Rahma");

            channl.Subscribe(user1);
            channl.Subscribe(user2);
            channl.Subscribe(user3);

            channl.UploadVideo("Design Patterns in C#");
            //Wahba got notified: 'Design Patterns in C#' from 3moJohnny 
            //Junior got notified: 'Design Patterns in C#' from 3moJohnny 
            //Rahma got notified: 'Design Patterns in C#' from 3moJohnny

            channl.UnSubscribe(user2);
            channl.UploadVideo("SOLID Principles Explained!");
            // Wahba got notified: 'SOLID Principles Explained!' from 3moJohnny 
            // Rahma got notified: 'SOLID Principles Explained!' from 3moJohnny 
            // مفيش نوتفكيشن هيروح ل جونيور لأنه عملت Unsubscribe
        }
    }
}
