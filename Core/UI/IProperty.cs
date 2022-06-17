using System;

namespace Core.UI
{
    public interface IProperty<T>
    {
        T Value { get; }
        void SetValue(T newValue, bool force);
        event System.Action<T> OnValueChanged;
    }


    public class IntProperty : IProperty<int>
    {
        public int Value { get; private set; }

        public event System.Action<int> OnValueChanged;

        public IntProperty(int newValue)
        {
            SetValue(newValue, true);
        }

        public void SetValue(int newValue, bool force)
        {
            if (Value != newValue || force)
            {
                Value = newValue;
                RaiseOnValueChangedEvent();
            }
        }

        private void RaiseOnValueChangedEvent()
        {
            OnValueChanged?.Invoke(Value);
        }
    }

    public class FloatProperty : IProperty<float>
    {
        public float Value { get; private set; }

        public event Action<float> OnValueChanged;

        public void SetValue(float newValue, bool force)
        {
            if (Value != newValue || force)
            {
                Value = newValue;
                RaiseOnValueChangedEvent();
            }
        }

        private void RaiseOnValueChangedEvent()
        {
            OnValueChanged?.Invoke(Value);
        }
    }
}