using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSaving : MonoBehaviour
{
    private GameData gameData;
    private string currentName;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text[] leaderboard = new TMP_Text[10];
    [SerializeField] private TMP_Text[] leaderboardNames = new TMP_Text[10];

    // Start is called before the first frame update
    void Start()
    {
        
        setData();
        // Uncomment resetData function to reset game data
        resetData();
        LoadData();
        foreach (var x in gameData.leaderboardList)
        {
            Debug.Log(x.ToString());
        }
        if (score != null)
        {
            score.text = gameData.currentScore.ToString();
            
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
            gameData = new GameData(0, false, true);
            Debug.Log("default settings enabled");
        }

    }

    public void changeLeaderboard()
    {
        gameData.changeLeaderboard(gameData.currentScore, currentName);
        SaveData();
    }

    public void setScore(int score)
    {
        gameData.setCurrentScore(score);
    }

    public int getLeaderboard(int i)
    {
        return gameData.getLeaderboard(i);
    }

    public string getName(int i)
    {
        return gameData.getName(i);
    }

    public void printLeaderboard()
    {
        for (int i = 0; i < leaderboard.Length; i++)
        {
            leaderboard[i].text = getLeaderboard(i).ToString();
            leaderboardNames[i].text = getName(i);
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
            gameData = new GameData(0, false, true);
            Debug.Log("No saved data found. Using defaults.");
        }

    }

    public void restartGame()
    {
        gameData.restarted = true;
        SaveData();
    }

    public void changeName(string name)
    {
        currentName = name;
    }

    public void resetData()
    {
        gameData = new GameData(0, false, true);
        SaveData();
    }
}
