using System;
using NUnit.Framework;
    
namespace Learn.Others
{
    public class ReferenceTest
    {
        [Test]
        public void StringTest()
        {
            string str = "abc";
            string str2 = str; // 拷贝引用
            string str3 = "abc";
            Console.WriteLine(object.ReferenceEquals(str, str3));  // 为true，因为 CLR 内存查找会查找相同值, 所以字符串是不可变
            int a1 = 3;
            int a2 = 3;
            Console.WriteLine(object.ReferenceEquals(a1, a2)); // 为 false
        }

    }
}