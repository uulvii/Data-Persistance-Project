using System.IO;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    public static DataManager Instance; // Singleton Instance

    public string currentPlayerName; // Menüden gelen isim
    public string bestPlayerName;    // JSON'dan gelen rekor sahibi
    public int highScore;           // JSON'dan gelen rekor skor

    private void Awake()
    {
        // Singleton Pattern: Sahne deðiþse de bu obje silinmez
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadPlayerData(); // Oyun açýlýnca eski rekoru yükle
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // JSON Kayýt Fonksiyonu
    public void SavePlayerData(int score)
    {
        SaveData data = new SaveData();
        data.playerName = currentPlayerName;
        data.highScore = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // JSON Yükleme Fonksiyonu
    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.playerName;
            highScore = data.highScore;
        }
    }
    
  
}



