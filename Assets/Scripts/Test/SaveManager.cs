using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public string SettingsPath => Path.Combine(Application.persistentDataPath, "settings.json");

    public void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        SettingsData data = new SettingsData
        {
            IsSoundOn = true,
            A = new List<A>
            {
                new A { A1 = "string1", B2 = 5 },
                new A { A1 = "string2", B2 = 7 },
                new A { A1 = "string3", B2 = 8 }
            }
        };
        string json = JsonUtility.ToJson(data, prettyPrint:true);
        File.WriteAllText(SettingsPath, json);
    }

    public void Load()
    {
        if (File.Exists(SettingsPath))
        {
            string json = File.ReadAllText(SettingsPath);
            SettingsData data = JsonUtility.FromJson<SettingsData>(json);

            Debug.Log(data.IsSoundOn);
            Debug.Log(string.Join(';', data.A));
        }
    }
}
