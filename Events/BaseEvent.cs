using System;
using SimpleAtoms.Listeners;
using UnityEngine;

namespace SimpleAtoms.Events
{
    public abstract class BaseEvent<T> : ScriptableObject
    {
        #region Members

        protected event Action<T> _onValueChanged;

        #endregion

        #region Public Methods

        public void Raise(T aValue)
        {
            _onValueChanged?.Invoke(aValue);
        }

        public void AddListener(BaseListener<T> aListener)
        {
            _onValueChanged += aListener.OnEventRaised;
        }

        public void RemoveListener(BaseListener<T> aListener)
        {
            _onValueChanged -= aListener.OnEventRaised;
        }

        #endregion
    }
}