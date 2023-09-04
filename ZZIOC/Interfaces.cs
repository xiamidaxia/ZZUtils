using System;

namespace ZZIOC
{
    public class ZZIOCException : Exception
    {
        public ZZIOCException(string message): base(message)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Method)]
    public class InjectAttribute : Attribute
    {
    }

    public enum Lifestyle: byte
    {
        Transient = 0,
        Singleton = 1,
        Scoped = 2,
    }

    public interface IObjectResolver
    {
        Lifestyle Lifestyle(Type type);
        T Resolve<T>();

        object Resolve(Type type);
    }

    public interface IScopedObjectResolver : IObjectResolver, IDisposable
    {
    }
}