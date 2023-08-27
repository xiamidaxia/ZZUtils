using System;
using JetBrains.Annotations;

namespace ZZUtils
{
    /// <summary>
    /// var Action action = () => {};
    /// var dispose = Disposable.create(action);
    /// </summary>
    public class Disposable: IDisposable
    {
        [CanBeNull] private Action mDispose { get; set; }

        public static IDisposable Create(Action dispose)
        {
            return new Disposable(dispose);
        }

        public Disposable()
        {
        }

        public Disposable(Action dispose)
        {
            mDispose = dispose;
        }

        public bool Disposed
        {
            get => mDispose == null;
        }


        public void Push(params IDisposable[] disposeList)
        {
            foreach (var dispose in disposeList)
            {
                mDispose += () => dispose.Dispose();
            }
        }
        
        public void Dispose()
        {
            mDispose?.Invoke();
            mDispose = null;
        }

        // public static Disposable operator +(Disposable dispose1, Disposable dispose2)
        // {
        //     var dispose = new Disposable();
        //     dispose.mDispose += dispose2.mDispose;
        //     return dispose;
        // }
        //
        // public static Disposable operator -(Disposable dispose1, Disposable dispose2)
        // {
        //     var dispose = new Disposable(dispose1.mDispose);
        //     dispose.mDispose -= dispose2.mDispose;
        //     return dispose;
        // }
        //
    }
}

