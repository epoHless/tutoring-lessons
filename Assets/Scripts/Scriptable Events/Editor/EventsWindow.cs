using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Scriptable_Events.Editor
{
    public class EventsWindow : EditorWindow
    {
        [MenuItem("Tools/Events Window")]
        private static void ShowWindow()
        {
            var window = GetWindow<EventsWindow>();
            window.titleContent = new GUIContent("Events Window");
            window.Show();
        }

        private UnityEditor.Editor Editor;
        private string assetName;
        
        private void OnGUI()
        {
            GUILayout.BeginHorizontal();

            using (new GUILayout.VerticalScope(GUILayout.Width(200)))
            {
                for (int i = 0; i < ScriptableEventsManager.ScriptableEvents.Count; i++)
                {
                    using (new GUILayout.HorizontalScope())
                    {
                        if (GUILayout.Button($"{ScriptableEventsManager.ScriptableEvents[i].name}"))
                        {
                            Editor = UnityEditor.Editor.CreateEditor(ScriptableEventsManager.ScriptableEvents[i]);
                        }
                        
                        if (GUILayout.Button("-", GUILayout.Width(25)))
                        {
                            DeleteAsset(ScriptableEventsManager.ScriptableEvents[i]);
                        }
                    }
                }

                GUILayout.FlexibleSpace();

                using (new GUILayout.HorizontalScope())
                {
                    assetName = GUILayout.TextField(assetName);

                    if (GUILayout.Button("Create", GUILayout.Width(50)))
                    {
                        if (!CreateAsset())
                        {
                            EditorGUILayout.HelpBox("Could not create asset", MessageType.Error);
                        }
                    }
                }
                
            }

            using (new GUILayout.VerticalScope())
            {
                if (Editor != null)
                {
                    GUILayout.Label(Editor.target.name.ToUpper());
                    Editor.OnInspectorGUI();
                }
            }

            GUILayout.EndHorizontal();
        }

        private void DeleteAsset(ScriptableEvent _event)
        {
            string path = AssetDatabase.GetAssetPath(_event);
            
            if (Editor.target == _event)
            {
                Editor = null;
            }

            Editor = UnityEditor.Editor.CreateEditor(ScriptableEventsManager.ScriptableEvents[0]);
            
            ScriptableEventsManager.ScriptableEvents.Remove(_event);
            AssetDatabase.DeleteAsset(path);
            AssetDatabase.Refresh();
        }

        private bool CreateAsset()
        {
            if (assetName == String.Empty) return false;

            var item = ScriptableObject.CreateInstance<ScriptableEvent>();
            AssetDatabase.CreateAsset(item, String.Concat(ScriptableEventsManager.eventsPath, $"{assetName}.asset"));

            ScriptableEventsManager.ScriptableEvents.Add(item);
            AssetDatabase.Refresh();
            
            assetName = String.Empty;
            
            return true;
        }
    }
}