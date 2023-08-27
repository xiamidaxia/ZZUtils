using System;

namespace ZZUtils
{
    public interface IReadonlyReactiveProperty<T>
    {
        T Value { get;  }
        IDisposable OnValueChange(Action<T> action);
        void UnValueChange(Action<T> action);
    }

    public interface IReactiveProperty<T> : IReadonlyReactiveProperty<T>
    {
        new T Value { get; set;  }
        void SetValueWithoutEvent(T newValue);
    }

    public class ReactiveProperty<T>: IReactiveProperty<T> where T: IEquatable<T>
    {

        protected T mValue;
        protected Action<T> mOnValueChanged;

        public ReactiveProperty(T defaultValue = default)
        {
            mValue = defaultValue;
        }

        public T Value
        {
            get => GetValue();
            set
            {
                if (value == null && mValue == null) return;
                if (value != null && value.Equals(mValue)) return;
                SetValue(value);
                mOnValueChanged?.Invoke(value);
            }

        }

        public void SetValueWithoutEvent(T newValue)
        {
            mValue = newValue;
        }

        public IDisposable OnValueChange(Action<T> onValueChanged)
        {
            mOnValueChanged += onValueChanged;
            return Disposable.Create(() =>
            {
                UnValueChange(onValueChanged);
            });
        }

        public void UnValueChange(Action<T> onValueChanged)
        {
            mOnValueChanged -= onValueChanged;
        }

        protected virtual void SetValue(T newValue)
        {
            mValue = newValue;
        }

        protected virtual T GetValue()
        {
            return mValue;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
        public static implicit operator T(ReactiveProperty<T> property)
        {
            return property.Value;
        }

    }
}
