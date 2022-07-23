using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour {
    public static DataManager Instance;

    public string playerName;

    public int highestScore;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    private class SaveData {
        public int highestScore;
    }

    public void SaveHighestScore() {
        SaveData saveData = new SaveData();
        saveData.highestScore = highestScore;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }

    public void LoadHighestScore() {
        string path = Application.persistentDataPath + "/saveData.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            highestScore = saveData.highestScore;
        }
    }
}
