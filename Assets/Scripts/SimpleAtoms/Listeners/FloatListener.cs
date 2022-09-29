using SimpleAtoms.Events;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleAtoms.Listeners
{
    [AddComponentMenu("Simple Atoms/Float Listener")]
    public class FloatListener : MonoBehaviour
    {
        [SerializeField]
        private FloatEvent _event; 

        [SerializeField]
        private UnityEvent<float> _response;

        private void OnEnable()
        {
            _event.AddListener(this);
        }

        private void OnDisable()
        {
            _event.RemoveListener(this);
        }

        public void OnEventRaised(float aValue)
        {
            _response.Invoke(aValue);
            
        }
    }
}