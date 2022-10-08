using SimpleAtoms.Variables;
using UnityEngine;

public class HealthBarBehaviour: HealthBarBaseBehaviour
{
    [SerializeField]
    private FloatVariable _healthValue;

    private void Start()
    {
        UpdateHealth(_healthValue.Value);
    }
}
