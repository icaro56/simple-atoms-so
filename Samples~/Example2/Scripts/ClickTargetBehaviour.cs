using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickTargetBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text _targetText;

    private void Awake()
    {
        _targetText.enabled = false;
    }

    public void OnClickedTargetCallback()
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessageRoutine());
    }

    private IEnumerator ShowMessageRoutine()
    {
        _targetText.enabled = true;

        yield return new WaitForSeconds(2);

        _targetText.enabled = false;
    }
}
