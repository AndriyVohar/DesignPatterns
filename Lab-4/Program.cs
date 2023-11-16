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
            public string Content { get; set; }
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
            void Attach(IUser user);
            void Detach(IUser user);
            void Notify();
        }

//System (Subject)
        public class System : ISystem {
            
            List<IUser> users = new List<IUser>();
            private List<News> newsCollection = new List<News>();
            public void Attach(IUser observer)
            {
                Console.WriteLine("System: Attached an user.");
                this.users.Add(observer);
            }
            public void Detach(IUser observer)
            {
                this.users.Remove(observer);
                Console.WriteLine("System: Detached an user.");
            }
            public void Notify()
            {
                Console.WriteLine("System: Notifying users...");

                foreach (var observer in users)
                {
                    observer.Update(newsCollection[newsCollection.Count - 1]); //Повідомлення про останню новину
                }
            }
            public void PublishNews(News news)
            {
                newsCollection.Add(news);
                this.Notify();
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

            public void SubscribeToNews(ISystem system)
            {
                system.Attach(this);
            }

            public void UnsubscribeFromNews(ISystem system)
            {
                system.Detach(this);
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
            user1.SubscribeToNews(newsSystem);
            user2.SubscribeToNews(newsSystem);

            // Публікація новин
            var news1 = new News { Title = "Text News 1", Topics = new[] { "text" }, Content = "Some text content" };
            var news2 = new News { Title = "Video News 1", Topics = new[] { "video" }, VideoUrl = "https://example.com/video1" };

            newsSystem.PublishNews(news1);
            newsSystem.PublishNews(news2);

            // Відписка одного користувача
            user1.UnsubscribeFromNews(newsSystem);

            // Публікація ще одної новини
            var news3 = new News { Title = "Text News 2", Topics = new[] { "text" }, Content = "Some other text content" };
            newsSystem.PublishNews(news3);
        }
    }
}
