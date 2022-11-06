using System;
using SimpleAtoms.Events;
using UnityEngine;

namespace SimpleAtoms.Variables
{
    public abstract class BaseVariable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        #region Members

        [SerializeField]
        protected T _initialValue;

        [SerializeField]
        protected BaseEvent<T> _valueChanged;

        [SerializeField]
        protected bool _forceEventCreation = true;

        [NonSerialized]
        protected T _value;

        #endregion

        #region Properties

        public BaseEvent<T> ValueChanged
        {
            get
            {
                if (_valueChanged == null && _forceEventCreation)
                    _valueChanged = CreateInstance<BaseEvent<T>>();

                return _valueChanged;
            }
        }

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                ValueChanged?.Raise(_value);
            }
        }

        #endregion

        #region Interface Methods

        public void OnAfterDeserialize()
        {
            _value = _initialValue;
        }

        public void OnBeforeSerialize()
        {

        } 
        
        #endregion
    }

}