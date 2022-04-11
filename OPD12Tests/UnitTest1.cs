using NUnit.Framework;
using OPD12;
using System;
using System.IO;

namespace OPD12Tests
{
    public class Tests
    {
        [Test]
        public void TestAddObserver()
        {
            Countdown countdown = new Countdown();
            Reader observer1 = new Reader("����");
            Reader observer2 = new Reader("����");
            countdown.addObserver(observer1);
            
            int expected = 1;
            int actual = countdown.numOfObserver();
            Assert.AreEqual(expected, actual);

            countdown.addObserver(observer2);
            expected = 2; actual = countdown.numOfObserver();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestRemoveObserver()
        {
            Countdown countdown = new Countdown();
            Reader observer1 = new Reader("����");
            Reader observer2 = new Reader("����");
            countdown.addObserver(observer1);
            countdown.addObserver(observer2);

            int expected = 2;
            int actual = countdown.numOfObserver();
            Assert.AreEqual(expected, actual);

            countdown.removeObserver(observer2);
            expected = 1; actual = countdown.numOfObserver();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestNotifyObserversForOneReader()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Countdown countdown = new Countdown();
            Reader observer1 = new Reader("����");
            countdown.addObserver(observer1);


            string str = "���� ������� ��������� - ��";
            int sleep = 1000;
            countdown.NotifyObservers("��", sleep);
            bool actual = stringWriter.ToString().Contains(str);

            Assert.IsTrue(actual);
        }

        [Test]
        public void TestNotifyObserversForManyReader()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Countdown countdown = new Countdown();
            Reader observer1 = new Reader("����");
            countdown.addObserver(observer1);
            Reader observer2 = new Reader("����");
            countdown.addObserver(observer2);

            string str1 = "���� ������� ��������� - ��";
            string str2 = "���� ������� ��������� - ��";
            int sleep = 1000;
            countdown.NotifyObservers("��", sleep);
            bool actual = stringWriter.ToString().Contains(str1) && stringWriter.ToString().Contains(str2);

            Assert.IsTrue(actual);
        }
    }
}