using UnityEngine;
using UnityEngine.UI;

public class HealthBarBaseBehaviour: MonoBehaviour
{
    [SerializeField]
    private Image _healthValueImage;

    public void UpdateHealth(float aValue)
    {
        _healthValueImage.fillAmount = aValue/ 100.0f;
    }
}
