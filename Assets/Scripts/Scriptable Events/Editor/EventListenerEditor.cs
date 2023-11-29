using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventListener))]
public class EventListenerEditor : Editor
{
    private EventListener script;

    private void OnEnable()
    {
        script = (EventListener)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Add To Event") && !script.Event.Contains(script))
        {
            script.Event.Add(script);
        }
    }
}
