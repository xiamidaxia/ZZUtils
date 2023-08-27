using System;
using ZZUtils;
using NUnit.Framework;

namespace ZZUtilsTests
{
    public class ReactivePropertyTest
    {
        [Test]
        public void Default()
        {
            var prop1 = new ReactiveProperty<int>();
            var prop2 = new ReactiveProperty<string>("");
            var prop3 = new ReactiveProperty<string>();
            Assert.AreEqual(prop1.Value, 0);
            Assert.AreEqual(prop2.Value, "");
            Assert.AreEqual(prop3.Value, null);
        }

        [Test]
        public void Operator()
        {
            var prop1 = new ReactiveProperty<string>("a");
            var prop2 = new ReactiveProperty<string>("b");
            Assert.AreEqual(prop1 + prop2, "ab");
        }

        [Test]
        public void OnValueChange()
        {
            var prop1 = new ReactiveProperty<int>(0);
            var valueChangeTime = 0;
            var dispose = prop1.OnValueChange((v) => valueChangeTime++);
            prop1.Value = 10;
            Assert.AreEqual(valueChangeTime, 1);
            prop1.Value = 10; // no change
            Assert.AreEqual(valueChangeTime, 1);
            prop1.Value = 11;
            Assert.AreEqual(valueChangeTime, 2);
            dispose.Dispose();
            prop1.Value = 12;
            Assert.AreEqual(valueChangeTime, 2);
        }
    }
    
}