using System;
using NUnit.Framework;

namespace Learn.Invoke
{

    delegate void SomeFunc();

    class SomeEvent
    {
        public event SomeFunc MyEvent;

        public void Invoke()
        {
            MyEvent?.Invoke();
        }
    }

    class InvokeTest
    {
        private Action act = () => { };
        // private Func<int, int> func; // 返回 int
        // private Predicate<int> func2; // 返回布尔
        [Test] 
        public void Base()
        {
            // 获取所有的委托
            var list = act.GetInvocationList();
            foreach (var del in list)
            {
                Console.WriteLine(">>> " + del.DynamicInvoke());
            }
        }

        [Test]
        public void TestEvent()
        {
            var e = new SomeEvent();
            e.MyEvent += () =>
            {
                Console.WriteLine(">>> Event Invoke");
            };
            // e.MyEvent.Invoke() 无法直接调用
            e.Invoke();

        }

    }
}