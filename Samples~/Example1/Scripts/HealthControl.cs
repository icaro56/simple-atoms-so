using SimpleAtoms.Variables;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    [SerializeField]
    private FloatVariable _healthVariable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _healthVariable.Value = Mathf.Min(_healthVariable.Value + 10, 100);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            _healthVariable.Value = Mathf.Max(_healthVariable.Value - 10, 0);
        }
    }
}
