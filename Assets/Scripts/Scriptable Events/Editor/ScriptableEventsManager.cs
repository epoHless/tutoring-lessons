using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class ScriptableEventsManager
{
    public static readonly string eventsPath = "Assets/Scripts/Scriptable Events/Editor/";
    private static List<ScriptableEvent> _scriptableEvents;

    public static List<ScriptableEvent> ScriptableEvents => _scriptableEvents;

    static ScriptableEventsManager()
    {
        EditorSceneManager.activeSceneChangedInEditMode -= OnSceneChanged;
        EditorSceneManager.activeSceneChangedInEditMode += OnSceneChanged;
        
        AssemblyReloadEvents.afterAssemblyReload -= OnAssemblyReloaded;
        AssemblyReloadEvents.afterAssemblyReload += OnAssemblyReloaded;
    }

    private static void OnAssemblyReloaded()
    {
        if (FetchEvents(eventsPath))
        {
            Debug.Log($"Events Correctly Fetched");
        }
    }

    private static void OnSceneChanged(Scene _scene, Scene _loadSceneMode)
    {
        if (FetchEvents(eventsPath))
        {
            Debug.Log($"Events Correctly Fetched");
        }
    }

    /// <summary>
    /// Fetches all the requested items at a given path, in this case, ScriptableEvents
    /// I moved this as a method as i dont need the scene parameters from above and now it can also be reused
    /// </summary>
    /// <param name="_path"></param>
    /// <returns></returns>
    private static bool FetchEvents(string _path)
    {
        _scriptableEvents = new List<ScriptableEvent>();

        var guids = AssetDatabase.FindAssets("t:ScriptableObject", new[] { _path });

        if (guids == null || guids.Length == 0)
        {
            _scriptableEvents = null;
            return false;
        }
        
        foreach (var guid in guids)
        {
            var assetPath = AssetDatabase.GUIDToAssetPath(guid);
            var _event = AssetDatabase.LoadAssetAtPath<ScriptableEvent>(assetPath);

            if (_event)
            {
                Debug.Log($"Found {_event.name}!");

                _event.Clear();

                var items = GameObject.FindObjectsOfType<EventListener>().Where(_listener => _listener.Event == _event);

                foreach (var listener in items)
                {
                    _event.Add(listener);
                }
                
                _scriptableEvents.Add(_event);
            }
        }
        
        return true;
    }
}
