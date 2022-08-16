using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public Text BestScoreText;
    public string BestPlayer;
    public int BestScore;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    [System.Serializable]
    class SaveBestScore
    {
        public Text BestScoreText;
        public string BestPlayer;
        public int BestScore;
    }

    public void StoreBestScore(string BestPlayer, int BestScore)
    {
        //BestScoreText.text = $"Best Score : {BestPlayer} : {BestScore}";

        SaveBestScore dataBestScore = new SaveBestScore();
        dataBestScore.BestScore = BestScore;
        dataBestScore.BestPlayer = BestPlayer;

        string json = JsonUtility.ToJson(dataBestScore);

        File.WriteAllText(Application.persistentDataPath + "/saveNamefile.json", json);

        //Debug.Log("Name stored: " + playerName);
    }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/saveNamefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveBestScore dataBestScore = JsonUtility.FromJson<SaveBestScore>(json);

            BestScore = dataBestScore.BestScore;
            BestPlayer = dataBestScore.BestPlayer;
        }
    }
}
