using SimpleAtoms.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleAtoms.Listeners
{
    [AddComponentMenu("Simple Atoms/Listener/Variables/Float")]
    public class FloatVariableListener : MonoBehaviour
    {
        #region Members

        [SerializeField]
        private FloatVariable _variable; 

        [SerializeField]
        private UnityEvent<float> _response;

        [SerializeField]
        private bool _forceEventOnRegister = true;

        #endregion

        #region Unity Methods

        private void OnEnable()
        {
            _variable.ValueChanged.AddListener(this);

            if (_forceEventOnRegister)
                OnEventRaised(_variable.Value);
        }

        private void OnDisable()
        {
            _variable.ValueChanged.RemoveListener(this);
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