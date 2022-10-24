using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update
    //ENCAPSULATION
    public static MainManager Instance { get; private set; }
    public Color factoryColor;
    public string factoryName;
    public int currentLevel;

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData
    {
        public string factoryNameS;
        public int currentLevelS;
        public Color factoryColorS;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.factoryColorS = factoryColor;
        data.factoryNameS = factoryName;
        data.currentLevelS = currentLevel;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); 
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            factoryName = data.factoryNameS;
            currentLevel = data.currentLevelS;
            factoryColor = data.factoryColorS;
        }
    }
}
