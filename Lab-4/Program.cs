using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_4
{
    internal class Program
    {
        public class News
        {
            public string Title { get; set; }
            public string[] Topics { get; set; }
        }
        public class NewsText : News {
            public string Content { get; set; }
        }
        public class NewsVideo: News
        {
            public string VideoUrl { get; set; }
        }
        //Observer
        public interface IUser
        {
            void Update(News news);
        }
//Subject
        public interface ISystem
        {
            void AttachForText(IUser user);
            void AttachForVideo(IUser user);
            void DetachForText(IUser user);
            void DetachForVideo(IUser user);
            void NotifyText();
            void NotifyVideo();
        }

//System (Subject)
        public class System : ISystem {
            
            List<IUser> usersForText = new List<IUser>();
            List<IUser> usersForVideo = new List<IUser>();  
            private List<NewsText> newsCollectionText = new List<NewsText>();
            private List<NewsVideo> newsCollectionVideo = new List<NewsVideo>();
            public void AttachForText(IUser observer)
            {
                Console.WriteLine("System: Attached an user.");
                this.usersForText.Add(observer);
            }
            public void DetachForText(IUser observer)
            {
                this.usersForText.Remove(observer);
                Console.WriteLine("System: Detached an user.");
            }
            public void AttachForVideo(IUser observer)
            {
                Console.WriteLine("System: Attached an user.");
                this.usersForVideo.Add(observer);
            }
            public void DetachForVideo(IUser observer)
            {
                this.usersForVideo.Remove(observer);
                Console.WriteLine("System: Detached an user.");
            }
            public void NotifyText()
            {
                Console.WriteLine("System: Notifying users...");

                foreach (var observer in usersForText)
                {
                    observer.Update(newsCollectionText[newsCollectionText.Count - 1]); //Повідомлення про останню новину
                }
            }
            public void NotifyVideo()
            {
                Console.WriteLine("System: Notifying users...");

                foreach (var observer in usersForVideo)
                {
                    observer.Update(newsCollectionVideo[newsCollectionVideo.Count - 1]); //Повідомлення про останню новину
                }
            }
            public void PublishNewsText(NewsText news)
            {
                newsCollectionText.Add(news);
                this.NotifyText();
            }
            public void PublishNewsVideo(NewsVideo news)
            {
                newsCollectionVideo.Add(news);
                this.NotifyVideo();
            }
        }

//User (Observer)
        public class User : IUser
        {
            private string name;

            public User(string name)
            {
                this.name = name;
            }

            public void Update(News news)
            {
                Console.WriteLine($"{name} received an update: {news.Title}");
            }

            public void SubscribeToNewsText(ISystem system)
            {
                system.AttachForText(this);
            }
            public void SubscribeToNewsVideo(ISystem system)
            {
                system.AttachForVideo(this);
            }

            public void UnsubscribeFromNewsText(ISystem system)
            {
                system.DetachForText(this);
            }
            public void UnsubscribeFromNewsVideo(ISystem system)
            {
                system.DetachForVideo(this);
            }
        }

        static void Main(string[] args)
        {
            //4.Система публікує новини. Новини бувають в текстовому форматі та відео.
            //Кожна новина це об’єкт що містить заголовок, теми новини(масив слів) та
            //текст новини чи  URL відео. Публікація новини  полягає у додаванні відповідного
            //об'єкту до однієї із 2 колекцій.   Користувач може підписатися на всі текстові
            //новини, на всі відео новини чи тільки текстові новини за вказаною темою.
            //При публікації новини надсилати користувачу, згідно з його підпискою, 
            //повідомлення про новину (в консоль вивести заголовок новини).

            // Створення об'єктів
            var newsSystem = new System();

            var user1 = new User("User1");
            var user2 = new User("User2");

            // Підписка користувачів на різні типи новин
            user1.SubscribeToNewsText(newsSystem);
            user2.SubscribeToNewsVideo(newsSystem);

            // Публікація новин
            var news1 = new NewsText { Title = "Text News 1", Topics = new[] { "text" }, Content = "Some text content" };
            var news2 = new NewsVideo { Title = "Video News 1", Topics = new[] { "video" }, VideoUrl = "https://example.com/video1" };

            newsSystem.PublishNewsText(news1);
            newsSystem.PublishNewsVideo(news2);

            // Відписка одного користувача
            user2.UnsubscribeFromNewsVideo(newsSystem);

            // Публікація ще одної новини
            var news3 = new NewsText { Title = "Text News 2", Topics = new[] { "text" }, Content = "Some other text content" };
            newsSystem.PublishNewsText(news3);
        }
    }
}
