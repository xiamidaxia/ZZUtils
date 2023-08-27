using System;
using System.Collections.Generic;

namespace ZZUtils
{
    public class Events
    {
        private static Events mGlobalEvents = new Events();
        private Dictionary<Type, IEvent> mTypeEvents = new Dictionary<Type, IEvent>();

        // public static T Get<T>() where T: IEvent
        // {
        // }
        // public T GetEvent<T>() where T: IEvent {
        //     
        // }

    }
}
