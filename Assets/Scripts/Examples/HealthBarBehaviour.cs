using SimpleAtoms.Variables;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour: MonoBehaviour
{
    [SerializeField]
    private FloatVariable _healthValue;

    [SerializeField]
    private Image _healthValueImage;

    private void Start()
    {
        UpdateHealth(_healthValue.Value);
    }

    public void UpdateHealth(float aValue)
    {
        _healthValueImage.fillAmount = aValue/ 100.0f;
    }
}
