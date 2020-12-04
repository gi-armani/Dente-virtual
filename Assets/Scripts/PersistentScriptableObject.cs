using System.IO;
using UnityEngine;

[CreateAssetMenu()]
public abstract class PersistentScriptableObject : ScriptableObject
{
    public void Save(string path)
    {
        var barValueJson = JsonUtility.ToJson(this);
        File.WriteAllText(path, barValueJson);
    }

    public void Load(string path)
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, this);
        }
        else
        {
            Save(path);
        }
    }

    public string GetPath()
    {
        var directoryPath = Path.Combine(Application.persistentDataPath, this.GetType().Name);

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        return Path.Combine(directoryPath, name + ".json");
    }

    private void OnEnable()
    {
        string path = GetPath();
        Load(path);
    }
}
