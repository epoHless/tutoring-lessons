using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(ScriptableEvent))]
public class ScriptableEventEditor : Editor
{
    private ScriptableEvent script;

    private void OnEnable()
    {
        script = (ScriptableEvent)target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Clear"))
        {
            script.Clear();
        }
        
        for (int i = 0; i < script.Listeners.Count; i++)
        {
            using (new GUILayout.HorizontalScope(GUI.skin.box))
            {
                GUI.enabled = false;
                EditorGUILayout.ObjectField(script.Listeners[i].gameObject, typeof(GameObject), false);
                GUI.enabled = true;

                if (GUILayout.Button("-", GUILayout.Width(25)))
                {
                    script.Remove(script.Listeners[i]);;
                }
            }
        }

        using (new GUILayout.HorizontalScope())
        {
            if (GUILayout.Button("Subscribe All"))
            {
                var items = GameObject.FindObjectsOfType<EventListener>().Where(_listener => _listener.Event == script);

                foreach (var listener in items)
                {
                    script.Add(listener);
                }
            }
            
            if (GUILayout.Button("Trigger Event"))
            {
                script.Trigger();
            }
        }
    }
}
