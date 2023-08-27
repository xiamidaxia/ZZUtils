using System;
using System.Reflection;
using NUnit.Framework;

/**
 * 特性学习
 */
namespace Learn.AttributeTest
{
    public class CustomAttr: Attribute
    {
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class MultiAttr : Attribute
    {
        
    }

    public class ConstructAttribute : Attribute
    {
        private string mProp;
        public string Prop {
            get => mProp;
            set => mProp = value;
        }


    }

    [CustomAttr]
    [MultiAttr, MultiAttr]
    [Construct(Prop = "xxx")]
    public class MyClass
    {
    }

    public class AttributeTest
    {
        // 给返回值添加特性
        [return: CustomAttr]
        public string someMethod([CustomAttr] string a)
        {
            return a;
        }

        [Test]
        public void IsDefined()
        {
            var type = typeof(MyClass);
            if (type.IsDefined(typeof(ConstructAttribute), true))
            {
                ConstructAttribute attr = (ConstructAttribute)type.GetCustomAttribute(typeof(ConstructAttribute), true);
                Console.WriteLine($">>> custorm: {attr.Prop}");
            }

        }

    }

}