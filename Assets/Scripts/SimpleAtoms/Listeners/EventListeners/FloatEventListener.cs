using SimpleAtoms.Events;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleAtoms.Listeners
{
    [AddComponentMenu("Simple Atoms/Listener/Events/Float")]
    public class FloatEventListener : MonoBehaviour
    {
        #region Members

        [SerializeField]
        private FloatEvent _event; 

        [SerializeField]
        private UnityEvent<float> _response;

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

        public void OnEventRaised(float aValue)
        {
            _response.Invoke(aValue);
        }

        #endregion
    }
}