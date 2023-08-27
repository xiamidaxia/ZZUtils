using System;
using System.Reflection;
using NUnit.Framework;

/**
 * 反射相关学习
 */
namespace Learn.Refelction
{
    public class ReflectionLearn
    {
        Assembly assembly = Assembly.Load("Learn");
        [Test]
        public void LoadDLL()
        {
            // 加载dll
            // 加载dll file
            // Assembly assembly2 = Assembly.LoadFile("/xxxx/xxLearn.dll");
            // Assembly assembly2 = Assembly.LoadFrom("/xxxx/xxLearn.dll"); 
            foreach (var model in assembly.GetModules())
            {
                Console.WriteLine(">>>> module: " + model.FullyQualifiedName);
            }
            foreach (var model in assembly.GetTypes())
            {
                Console.WriteLine(">>>> type: " + model.FullName);
            }
        }

        [Test]
        public void CreateFromType()
        {
            var type = assembly.GetType("Learn.Refelction.TestClass");
            // CreateInstance 第一个参数支持私有调用
            TestClass testClass = (TestClass)Activator.CreateInstance(type);
            Console.WriteLine(">>>" + testClass.Value);
            TestClass testClass2 = (TestClass)Activator.CreateInstance(type, new object[]{ 123 } );
            Console.WriteLine(">>>" + testClass2.Value);
        }

        [Test]
        public void CreateGenericClass()
        {
            var type = assembly.GetType("Learn.Refelction.GenericClass`2");
            var newType = type.MakeGenericType(new Type[] { typeof(string), typeof(int) });
            var cls = (GenericClass<string, int>)Activator.CreateInstance(newType, new object[]{ "string", 10 });
            Console.WriteLine(">>>" + cls.Value + cls.Value2);
        }
        
        [Test]
        public void InvokeMethod()
        {
            var type = assembly.GetType("Learn.Refelction.TestClass");
            // 1. 单个方法
            MethodInfo method = type.GetMethod("Method1");
            // 2. 加上范型的方法
            MethodInfo methodWithGenerics = type.GetMethod("Method2", new Type[] { typeof(int) });
            object obj = Activator.CreateInstance(type);
            // 3. 调用，静态方法第一个参数可以为null, 第二个为参数数组
            method.Invoke(obj, null);
        }

        [Test]
        public void InvokePrivateMethod()
        {
            var type = assembly.GetType("Learn.Refelction.TestClass");
            // 1. 调用私有方法
            MethodInfo method = type.GetMethod("PrivateMethod", BindingFlags.Instance | BindingFlags.NonPublic);
            object obj = Activator.CreateInstance(type);
            method.Invoke(obj, null);

        }

        [Test]
        public void GetProperties()
        {
            var type = typeof(PropertyClass);
            var obj = Activator.CreateInstance(type);

            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine($"method: {prop.Name}, ");
                // prop.SetValue();
                // prop.GetValue()
            }
        }

    }
    public class GenericClass<T, B>
    {
        public T Value;
        public B Value2;

        public GenericClass(T v1, B v2)
        {
            Value = v1;
            Value2 = v2;
        }
    }

    public class PropertyClass
    {
        public PropertyClass()
        {
        }
        public int MyProperty { get; set; }
        public int MyInt = 10;
        public string MyString = "xxxx";
        private int mPrivateInt = 10;
    }

    public class TestClass
    {
        public int Value = 3;

        public TestClass()
        {
        }

        public TestClass(int arg)
        {
            Value = arg;
        }

        public void Method1()
        {
            Console.WriteLine(">> Invoke method1");
        }

        private void PrivateMethod()
        {
            Console.WriteLine(">> Invoke private method");
        }
    }

}