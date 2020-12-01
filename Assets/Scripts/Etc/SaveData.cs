using UnityEditor;
using UnityEngine;
using System.Linq;
public class SaveData : MonoBehaviour
{
    public PersistentScriptableObject[] persistentScriptableObjects = null;

    private void OnApplicationQuit()
    {
        foreach(var data in persistentScriptableObjects)
        {
            data.Save(data.GetPath());
        }
        Debug.Log("Saved Data");
    }

#if UNITY_EDITOR
    [ContextMenu("Get Persistent SO")]
    public void GetPersistentSOArray()
    {
        persistentScriptableObjects = AssetDatabase.LoadAllAssetsAtPath("Assets/ScriptableObjects") as PersistentScriptableObject[];
    }
#endif
}