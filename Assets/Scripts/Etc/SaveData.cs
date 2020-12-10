using UnityEditor;
using UnityEngine;
using System.Linq;
public class SaveData : MonoBehaviour
{
    public PersistentScriptableObject[] persistentScriptableObjects = null;

    /// <summary>
    /// App must be quitted via script on Android, but does not get called on Iphone.
    /// </summary>
    private void OnApplicationQuit()
    {
        SaveAll();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveAll();
        }
    }

    private void SaveAll()
    {
        foreach (PersistentScriptableObject data in persistentScriptableObjects)
        {
            data.Save(data.GetPath());
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Get Persistent SO")]
    public void GetPersistentSOArray()
    {
        persistentScriptableObjects = AssetDatabase.LoadAllAssetsAtPath("Assets/ScriptableObjects") as PersistentScriptableObject[];
    }
#endif
}