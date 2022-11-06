using System;
using SimpleAtoms.Listeners;
using UnityEngine;

namespace SimpleAtoms.Events
{
    [CreateAssetMenu(menuName = "SimpleAtoms/Events/Void")]
    public class VoidEvent : ScriptableObject
    {
        #region Members

        protected event Action _onEvent;

        #endregion

        #region Public Methods

        public void Raise()
        {
            _onEvent?.Invoke();
        }

        public void AddListener(VoidEventListener aListener)
        {
            _onEvent += aListener.OnEventRaised;
        }

        public void RemoveListener(VoidEventListener aListener)
        {
            _onEvent -= aListener.OnEventRaised;
        }

        #endregion
    }
}