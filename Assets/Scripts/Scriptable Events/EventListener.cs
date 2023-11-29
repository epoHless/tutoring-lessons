using System;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    [SerializeField] private ScriptableEvent _event;
    [SerializeField] private UnityEvent _eventToTrigger;

    public ScriptableEvent Event => _event;
    
    private void OnEnable()
    {
        _event.Add(this);
    }

    private void OnDisable()
    {
        _event.Remove(this);
    }

    public void TriggerEvent()
    {
        _eventToTrigger.Invoke();
    }
}