using System;
using System.Collections.Generic;

namespace Learn.Others
{
    internal sealed class Pair<T1, T2> : IEquatable<Pair<T1, T2>>
    {
        private static readonly IEqualityComparer<T1> FirstComparer = EqualityComparer<T1>.Default;
        private static readonly IEqualityComparer<T2> SecondComparer = EqualityComparer<T2>.Default;
        private readonly T1 first;
        private readonly T2 second;
        public T1 First
        {
            get => first;
        }
        public T2 Second
        {
            get => second;
        }

        public bool Equals(Pair<T1, T2> other)
        {
            return other != null
                   && FirstComparer.Equals(First, other.first)
                   && SecondComparer.Equals(Second, other.Second);
        }

        public override bool Equals(object o)
        {
            return Equals(o as Pair<T1, T2>);
        }

        public override int GetHashCode()
        {
            return FirstComparer.GetHashCode(first) * 37 + SecondComparer.GetHashCode(second);
        }
    }

    public class EqualityTest
    {
        
    }
}