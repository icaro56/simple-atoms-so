using SimpleAtoms.Events;
using UnityEngine;

namespace SimpleAtoms.Listeners
{
    public abstract class BaseEventListener<T> : BaseListener<T>
    {
        #region Members

        [SerializeField]
        private BaseEvent<T> _event; 

        #endregion

        #region Unity Methods

        private void OnEnable()
        {
            _event.AddListener(this);
        }

        private void OnDisable()
        {
            _event.RemoveListener(this);
        }

        #endregion
    }
}