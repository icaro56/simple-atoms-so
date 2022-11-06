using UnityEngine;
using UnityEngine.Events;

namespace SimpleAtoms.Listeners
{
    public abstract class BaseListener<T> : MonoBehaviour
    {
        #region Members

        [SerializeField]
        protected UnityEvent<T> _response;

        #endregion

        #region Public Methods

        public virtual void OnEventRaised(T aValue)
        {
            _response.Invoke(aValue);
        }

        #endregion
    }
}