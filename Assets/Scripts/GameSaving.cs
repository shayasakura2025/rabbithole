using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSaving : MonoBehaviour
{
    private GameData gameData;
    public TMP_Text score;
    public TMP_Text highScore;
    public TMP_Text[] leaderboard = new TMP_Text[10];

    // Start is called before the first frame update
    void Start()
    {
        
        setData();
        LoadData();
        foreach (var x in gameData.leaderboardList)
        {
            Debug.Log(x.ToString());
        }
        if (score != null)
        {
            score.text = gameData.currentScore.ToString();
            highScore.text = gameData.highestScore.ToString();
            changeLeaderboard(gameData.currentScore);
        }
        if (leaderboard[0] != null)
        {
            printLeaderboard();
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

    public void changeLeaderboard(int score)
    {
        gameData.changeLeaderboard(score);
        SaveData();
    }

    public int getLeaderboard(int i)
    {
        return gameData.getLeaderboard(i);
    }

    public void printLeaderboard()
    {
        for (int i = 0; i < leaderboard.Length; i++)
        {
            leaderboard[i].text = getLeaderboard(i).ToString();
        }
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
