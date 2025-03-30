using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSaving : MonoBehaviour
{
    private GameData gameData;
    public TMP_Text score;
    public TMP_Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        setData();
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
        string jsonData = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData", jsonData);
        PlayerPrefs.Save(); // Make sure the data is written immediately
        Debug.Log("Data saved: " + jsonData);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("GameData"))
        {
            string json = PlayerPrefs.GetString("GameData");
            gameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Data loaded: " + json);
        }
        else
        {
            gameData = new GameData(0, 0, false);
            Debug.Log("No saved data found. Using defaults.");
        }

    }
}
