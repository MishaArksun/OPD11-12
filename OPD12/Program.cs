using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace OPD12
{
    static class Program
    {
        private static void Main(string[] args)
        {
            Countdown countdown = new Countdown();
            Reader observer1 = new Reader("Петр");
            Reader observer2 = new Reader("Иван");
            Reader observer3 = new Reader("Кирилл");

            Console.WriteLine("Через сколько миллисекунд уведомить?");
            int sleep = Convert.ToInt32(Console.ReadLine());

            countdown.addObserver(observer1);
            countdown.addObserver(observer2);
            countdown.NotifyObservers("аа", sleep);

            countdown.addObserver(observer3);
            countdown.NotifyObservers("бб", sleep);

            countdown.removeObserver(observer2);
            countdown.NotifyObservers("вв", sleep);

            countdown.removeObserver(observer3);
            countdown.NotifyObservers("гг", sleep);

            Console.ReadKey();
        }


    }

    public interface Observer
    {
        void update(string message);
    }

    public class Reader : Observer
    {
        public string name { get; set; }

        public Reader(string name) => this.name = name;

        public void update(string message) => Console.WriteLine(name + " получил сообщение - " + message);
    }

    public interface Observable
    {
        void addObserver(Observer observer);
        void removeObserver(Observer observer);
        void NotifyObservers(string message, int sleep);
    }

    public class Countdown : Observable
    {

        private List<Observer> observers = new List<Observer>();

        public void addObserver(Observer observer) => observers.Add(observer);

        public void removeObserver(Observer observer) => observers.Remove(observer);

        public void NotifyObservers(string message, int sleep)
        {
            Thread.Sleep(sleep);
            foreach (var observer in observers)
            {
                observer.update(message);
            }
            Console.WriteLine("\n*************************\n");
        }

        public int numOfObserver() => observers.Count;
    }











































    /*
    class Program
    {
        static void Main(string[] args)
        {
            var countdown = new Countdown();
            var firstObserver = new FirstObserver();
            var secondObserver = new SecondObserver();

            countdown.subscribe(firstObserver);

            Console.Write("Enter delay in milisseconds: ");
            int delay;
            while (!int.TryParse(Console.ReadLine(), out delay)) { }
            countdown.notifyAll(delay, $"User event with delay {delay}");

            countdown.notifyAll(1000, "May I have your attention, please?");

            countdown.subscribe(secondObserver);
            countdown.notifyAll(2000, "Will the real Slim Shady please stand up?");

            countdown.unsubscribe(secondObserver);
            countdown.notifyAll(3000, "I repeat, will the real Slim Shady please stand up ?");

            countdown.unsubscribe(firstObserver);
            countdown.notifyAll(4000, "We're gonna have a problem here?");

            Console.ReadKey();
        }
    }



    public class Man
    {
        public string firstName;
        public string lastName;
        public int age;
    }

    public class Countdown
    {
        private List<Man> observers = new List<Man>();

        public void subscribe(Man man)
        {
            Console.WriteLine(man.GetType().Name + " subscribed\n");
            observers.Add(obj);
        }

        public void unsubscribe(MessageListener obj)
        {
            Console.WriteLine(obj.GetType().Name + " unsubscribed\n");
            observers.Remove(obj);
        }

        public void notifyAll(int delay, string message)
        {
            Console.WriteLine($"Notifying subscribers after delay {delay}");
            Thread.Sleep(delay);
            foreach (var listener in observers)
            {
                listener.update(message);
            }
        }
    }

    internal class FirstObserver : MessageListener
    {
        public void update(string message)
        {
            Console.WriteLine(message + " was received in firstObserver\n");
        }
    }

    internal class SecondObserver : MessageListener
    {
        public void update(string message)
        {
            Console.WriteLine(message + " was received in secondObserver\n");
        }
    }*/
}
