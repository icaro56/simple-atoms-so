using System;
using SimpleAtoms.Listeners;
using UnityEngine;

namespace SimpleAtoms.Events
{
    [CreateAssetMenu(menuName = "SimpleAtoms/Events/Float")]
    public class FloatEvent : ScriptableObject
    {
        private event Action<float> _onValueChanged;

        public void Raise(float aValue)
        {
            _onValueChanged?.Invoke(aValue);
        }

        public void AddListener(FloatListener aListener)
        {
            _onValueChanged += aListener.OnEventRaised;
        }

        public void RemoveListener(FloatListener aListener)
        {
            _onValueChanged -= aListener.OnEventRaised;
        }
    }
}