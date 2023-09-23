using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NameManager : MonoBehaviour
{
    public static NameManager Instance;

    public string playerName;
    public int score;
    public string nameToSet;

    private void Awake()
    {
        if (Instance != null)
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
        public string name;
        public int score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.name = playerName;
        data.score = GameObject.Find("MainManager").GetComponent<MainManager>().m_Points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore(int currentScore)
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            if (data.score < currentScore)
            {
                score = currentScore;
                nameToSet = playerName;
                GameObject.Find("MainManager").GetComponent<MainManager>().m_Points = currentScore;
                SaveScore();
            }
            else
            {
                score = data.score;
                nameToSet = data.name;
            }
        }
        else score = -100;
    }
}