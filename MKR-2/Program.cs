using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR2
{
    interface IObserver
    {
        void Update(Message message);
    }

    // Відправник повідомлень
    class MessageSender
    {
        private List<Action<Message>> messageSentHandlers = new List<Action<Message>>();

        public void AddMessageSentHandler(Action<Message> handler)
        {
            messageSentHandlers.Add(handler);
        }

        public void RemoveMessageSentHandler(Action<Message> handler)
        {
            messageSentHandlers.Remove(handler);
        }

        public void SendMessage(List<Message> messages)
        {
            OnMessageSent(messages);
        }

        protected void OnMessageSent(List<Message> messages)
        {
            foreach (var handler in messageSentHandlers)
            {
                foreach (var message in messages)
                {
                    handler(message);
                }
            }
        }
    }

    // Отримувач відповіді (спостерігач)
    class ResponseReceiver : IObserver
    {
        private readonly string name;

        public ResponseReceiver(string name)
        {
            this.name = name;
        }

        public void Update(Message message)
        {
            Console.WriteLine($"{name} відповідає на повідомлення: \"{message.Text}\" від {message.Sender}, {message.Date}");
        }
    }

    // Повідомлення
    class Message
    {
        public DateTime Date { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Text { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var sender = new MessageSender();
            var observers = new List<IObserver>
            {
                new ResponseReceiver("Отримувач повідомлень"),
            };

            foreach (var observer in observers)
            {
                sender.AddMessageSentHandler(observer.Update);
            }

            List<Message> messages = new List<Message>
            {
                new Message
                {
                    Date = DateTime.Now,
                    Sender = "Відправник 1",
                    Receiver = "Отримувач 1",
                    Text = "Пов1"
                },
                new Message
                {
                    Date = DateTime.Now,
                    Sender = "Відправник 2",
                    Receiver = "Отримувач 1",
                    Text = "Пов2"
                },
                new Message
                {
                    Date = DateTime.Now,
                    Sender = "Відправник 3",
                    Receiver = "Отримувач 1",
                    Text = "Пов3"
                },
                new Message
                {
                    Date = DateTime.Now,
                    Sender = "Відправник 4", Receiver = "Отримувач 1",
                    Text = "Пов4"
                }
            };

            sender.SendMessage(messages);

            Console.ReadLine();
        }
    }
}
