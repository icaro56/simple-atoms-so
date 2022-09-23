using System;
using SimpleAtoms.Events;
using UnityEngine;

namespace SimpleAtoms.Variables
{
    [CreateAssetMenu(menuName = "SimpleAtoms/Variables/Float")]
    public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField]
        private float _initialValue;

        [SerializeField]
        private FloatEvent _valueChanged;

        [NonSerialized]
        private float _value;

        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                _valueChanged?.Raise(_value);
            }
        }

        public void OnAfterDeserialize()
        {
            _value = _initialValue;
        }

        public void OnBeforeSerialize()
        {

        } 
    }
}

