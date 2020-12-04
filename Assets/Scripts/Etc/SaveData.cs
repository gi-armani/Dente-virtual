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
        Debug.Log("Saved Data On Quit");
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveAll();
            Debug.Log("Saved Data on Focus == false");
        }
    }

    /*
    /// <summary>
    /// Is not calling on Android
    /// </summary>
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveAll();
            Debug.Log("Saved Data on Pause == true");
        }
    }
    */

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