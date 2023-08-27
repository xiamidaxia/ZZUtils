using System;
using System.Reflection;

namespace ZZUtils
{
    public class Singleton<T> where T: Singleton<T>
    {
        private static T myInstance;

        public static T Instance
        {
            get
            {
                if (myInstance == null)
                {
                    var type = typeof(T);
                    var ctors = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                    var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                    if (ctor == null)
                    {
                        throw new Exception("Non Public Constructor Not Found in" + type.Name);
                    }

                    myInstance = ctor.Invoke(null) as T;
                }

                return myInstance;
            }
        }

    }
}

