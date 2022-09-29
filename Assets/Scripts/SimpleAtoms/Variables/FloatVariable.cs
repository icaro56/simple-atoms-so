using System;
using SimpleAtoms.Events;
using UnityEngine;

namespace SimpleAtoms.Variables
{
    [CreateAssetMenu(menuName = "SimpleAtoms/Variables/Float")]
    public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        #region Members

        [SerializeField]
        private float _initialValue;

        [SerializeField]
        private FloatEvent _valueChanged;

        [SerializeField]
        private bool _forceEventCreation = true;

        [NonSerialized]
        private float _value;

        #endregion

        #region Properties

        public FloatEvent ValueChanged
        {
            get
            {
                if (_valueChanged == null && _forceEventCreation)
                    _valueChanged = CreateInstance<FloatEvent>();

                return _valueChanged;
            }
        }

        public float Value
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

