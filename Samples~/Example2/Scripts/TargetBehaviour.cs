using SimpleAtoms.Events;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    [SerializeField]
    private VoidEvent _targetClicked;

    public void OnTargetClicked()
    {
        _targetClicked.Raise();
    }
}
