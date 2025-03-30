using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class GameSaving : MonoBehaviour
{
    private string path = "";
    private GameData gameData;
    public TMP_Text score;
    public TMP_Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        setData();
        SetPaths();
        LoadData();
        if (score != null)
        {
            score.text = gameData.currentScore.ToString();
            highScore.text = gameData.highestScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "GameData.json";
    }

    private void setData()
    {
        if (gameData == null)
        {
            gameData = new GameData(0, 0, false);
            Debug.Log("default settings enabled");
        }

    }

    public void setScore(int score)
    {
        gameData.setCurrentScore(score);
    }

    public void setHighestScore(int highest)
    {
        gameData.setHighestScore(highest);
    }

    public void setTutorial(bool state)
    {
        gameData.setTutorial(state);
    }

    public bool getTutorial()
    {
        return gameData.tutorial;
    }

    public void SaveData()
    {
        string savePath = path;

        Debug.Log("Saving Data at " + savePath);
        string settings = JsonUtility.ToJson(gameData);
        Debug.Log(settings);


        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(settings);
    }

    public void LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        GameData data = JsonUtility.FromJson<GameData>(json);
        Debug.Log(data.ToString());
        gameData = data;

    }
}
