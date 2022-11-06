using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickTargetBehaviour : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _targetText;

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
