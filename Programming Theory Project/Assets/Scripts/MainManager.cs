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
    public int moneyValue;
    public bool resourceUpgrade = false;
    public bool conveyorUpgrade = false;
    public bool loadGameUsed = false;

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
        public string factoryName;
        public int moneyValue;
        public Color factoryColor;
        public bool resourceUpgrade;
        public bool conveyorUpgrade;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.factoryColor = factoryColor;
        data.factoryName = factoryName;
        data.moneyValue = moneyValue;
        data.resourceUpgrade = resourceUpgrade;
        data.conveyorUpgrade = conveyorUpgrade;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); 
    }

    public void LoadGame()
    {
        loadGameUsed = true;
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            factoryName = data.factoryName;
            moneyValue = data.moneyValue;
            factoryColor = data.factoryColor;
            resourceUpgrade = data.resourceUpgrade;
            conveyorUpgrade = data.conveyorUpgrade;
        }
    }
}
