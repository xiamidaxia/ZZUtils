using System;
using ZZUtils;
using NUnit.Framework;

namespace EventTest
{
    public class EventTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Base()
        {
            var mEvent = new Event();
            var num = 0;
            Action listener = () => num++;
            mEvent.AddListener(listener);
            mEvent.Fire();
            Assert.AreEqual(num, 1);
            mEvent.RemoveListener(listener);
            mEvent.Fire();
            Assert.AreEqual(num, 1);
            var dispose = mEvent.AddListener(listener);
            mEvent.Fire();
            Assert.AreEqual(num, 2);
            dispose.Dispose();
            mEvent.Fire();
            Assert.AreEqual(num, 2);
        }

        [Test]
        public void WithParam()
        {
            var mEvent = new Event<int>();
            var num = 0;
            Action<int> listener = v => num += v;
            mEvent.AddListener(listener);
            mEvent.Fire(10);
            Assert.AreEqual(num, 10);
        }
    }
}
