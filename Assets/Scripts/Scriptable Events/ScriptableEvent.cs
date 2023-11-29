using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Event_", menuName = "Scriptable Events/New Event")]
public class ScriptableEvent : ScriptableObject
{
    private List<EventListener> _listeners;
    public List<EventListener> Listeners => _listeners;

    private void Awake()
    {
        _listeners = new List<EventListener>();
    }

    public void Add(EventListener _listener)
    {
        if(!_listeners.Contains(_listener))
        {
            _listeners.Add(_listener);
            Debug.Log($"{_listener.gameObject.name} is listening to: {name}");
        }
    }
    
    public void Remove(EventListener _listener)
    {
        if(_listeners.Contains(_listener)) _listeners.Remove(_listener);
    }

    public bool Contains(EventListener _listener)
    {
        return _listeners.Contains(_listener);
    }

    public void Clear()
    {
        _listeners.Clear();
    }

    public void Trigger()
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].TriggerEvent();
        }
    }
}
