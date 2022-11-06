using SimpleAtoms.Events;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleAtoms.Listeners
{
    public class VoidEventListener : MonoBehaviour
    {
        #region Members

        [SerializeField]
        protected UnityEvent _response;

        [SerializeField]
        private VoidEvent _event; 

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

        #region Public Methods

        public virtual void OnEventRaised()
        {
            _response.Invoke();
        }

        #endregion
    }
}