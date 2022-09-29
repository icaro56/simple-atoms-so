using System;
using SimpleAtoms.Listeners;
using UnityEngine;

namespace SimpleAtoms.Events
{
    [CreateAssetMenu(menuName = "SimpleAtoms/Events/Float")]
    public class FloatEvent : ScriptableObject
    {
        #region Members

        private event Action<float> _onValueChanged;

        #endregion

        #region Public Methods

        public void Raise(float aValue)
        {
            _onValueChanged?.Invoke(aValue);
        }

        public void AddListener(FloatEventListener aListener)
        {
            _onValueChanged += aListener.OnEventRaised;
        }

        public void RemoveListener(FloatEventListener aListener)
        {
            _onValueChanged -= aListener.OnEventRaised;
        }

        public void AddListener(FloatVariableListener aListener)
        {
            _onValueChanged += aListener.OnEventRaised;
        }

        public void RemoveListener(FloatVariableListener aListener)
        {
            _onValueChanged -= aListener.OnEventRaised;
        }

        #endregion
    }
}