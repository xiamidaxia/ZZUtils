using System;

namespace ZZUtils
{
    
    interface IEvent
    {
    }

    public class Event: IDisposable, IEvent
    {
        private Action mListeners;

        public IDisposable AddListener(Action listener)
        {
            mListeners += listener;
            return Disposable.Create(() =>
            {
                RemoveListener(listener);
            });
        }

        public void RemoveListener(Action listener)
        {
            mListeners -= listener;
        }

        public void Fire()
        {
            mListeners?.Invoke();
        }

        public void Dispose()
        {
            mListeners = null;
        }
    }

    public class Event<T>: IDisposable
    {
        private Action<T> mListeners;

        public IDisposable AddListener(Action<T> listener)
        {
            mListeners += listener;
            return Disposable.Create(() =>
            {
                RemoveListener(listener);
            });
        }

        public void RemoveListener(Action<T> listener)
        {
            mListeners -= listener;
        }

        public void Fire(T t)
        {
            mListeners?.Invoke(t);
        }

        public void Dispose()
        {
            mListeners = null;
        }
    }
    public class Event<T, K>: IDisposable
    {
        private Action<T, K> mListeners;

        public IDisposable AddListener(Action<T, K> listener)
        {
            mListeners += listener;
            return Disposable.Create(() =>
            {
                RemoveListener(listener);
            });
        }

        public void RemoveListener(Action<T, K> listener)
        {
            mListeners -= listener;
        }

        public void Fire(T t, K k)
        {
            mListeners?.Invoke(t, k);
        }

        public void Dispose()
        {
            mListeners = null;
        }
    }

    public class Event<T, K, S>: IDisposable
    {
        private Action<T, K, S> mListeners;

        public IDisposable AddListener(Action<T, K, S> listener)
        {
            mListeners += listener;
            return Disposable.Create(() =>
            {
                RemoveListener(listener);
            });
        }

        public void RemoveListener(Action<T, K, S> listener)
        {
            mListeners -= listener;
        }

        public void Fire(T t, K k, S s)
        {
            mListeners?.Invoke(t, k, s);
        }

        public void Dispose()
        {
            mListeners = null;
        }
    }
}

