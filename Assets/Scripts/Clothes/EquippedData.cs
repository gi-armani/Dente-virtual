using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EquippedData : MonoBehaviour
{
    [SerializeField] private List<GameObject> ClothGameObjects = new List<GameObject>();

    private static string path;

    private void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "EquippedData.json");
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveData();
        }
        if (focus)
        {
            LoadData();
        }
    }

    public void SaveData()
    {
        EquippedClothCollection equippedClothes = new EquippedClothCollection();
        equippedClothes.list = new List<EquippedClothData>();

        foreach (var cloth in ClothGameObjects)
        {
            if (cloth.activeSelf)
            {
                EquippedClothData data = new EquippedClothData(cloth.name, cloth.GetComponent<Image>().color);
                equippedClothes.list.Add(data);
            }
        }

        string json = JsonUtility.ToJson(equippedClothes);
        File.WriteAllText(path, json);
    }

    public void LoadData()
    {
        if (!File.Exists(path))
        {
            return;
        }
        EquippedClothCollection equippedClothes = new EquippedClothCollection();
        equippedClothes.list = new List<EquippedClothData>();

        string json = File.ReadAllText(path);

        JsonUtility.FromJsonOverwrite(json, equippedClothes);

        foreach (var clothData in equippedClothes.list)
        {
            GameObject obj = null;

            foreach (var match in ClothGameObjects)
                if (match.name == clothData.name) obj = match;

            if(obj != null)
            {
                obj.GetComponent<Image>().color = clothData.color;
                obj.SetActive(true);
            }
        }
    }
}

[System.Serializable]
public class EquippedClothData
{
    public string name;
    public Color color;

    public EquippedClothData(string name, Color color)
    {
        this.name = name;
        this.color = color;
    }
}

[System.Serializable]
public class EquippedClothCollection
{
    public List<EquippedClothData> list;
}
