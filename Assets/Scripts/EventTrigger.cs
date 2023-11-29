using UnityEngine;

/// <summary>
/// Dummy class, giusto per testare il trigger dell'evento
/// </summary>
public class EventTrigger : MonoBehaviour
{
    [SerializeField] private ScriptableEvent _event;

    private void Start()
    {
        _event.Trigger();
    }
}

