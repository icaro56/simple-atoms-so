using SimpleAtoms.Variables;
using UnityEngine;

namespace SimpleAtoms.Listeners
{
    public abstract class BaseVariableListener<T> : BaseListener<T>
    {
        #region Members

        [SerializeField]
        private BaseVariable<T> _variable; 

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
    }
}