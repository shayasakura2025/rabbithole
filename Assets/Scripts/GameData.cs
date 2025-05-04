using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int currentScore;
    public int[] leaderboardList = new int[10];
    public string[] namesList = new string[10];
    public bool tutorial;
    public bool restarted;
    public int mode;
    // Start is called before the first frame update
    public GameData(int currentScore, bool tutorial, bool restarted, int mode)
    {
        this.currentScore = currentScore;
        resetLeaderboard();
        this.tutorial = tutorial;
        this.restarted = restarted;
        this.mode = mode;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCurrentScore(int score)
    {
        currentScore = score;
    }
    
    public void setTutorial(bool state)
    {
        tutorial = state;
    }

    public void changeLeaderboard(int score, string name)
    {
        if (score <= leaderboardList[9])
        {
            Debug.Log("No change to leaderboard");
        }
        else if (restarted == true)
        {
            Debug.Log("Changing leaderboard");
            bool replaced = false;
            int prevScore = 0;
            int thisScore = 0;
            string prevName = "";
            string thisName = "";
            for (int i = 0; i < leaderboardList.Length; i++)
            {
                if (score > leaderboardList[i] && replaced == false)
                {
                    thisScore = leaderboardList[i];
                    thisName = namesList[i];
                    leaderboardList[i] = score;
                    namesList[i] = name;
                    replaced = true;
                }
                else if (replaced == true)
                {
                    prevScore = thisScore;
                    thisScore = leaderboardList[i];
                    prevName = thisName;
                    thisName = namesList[i];
                    leaderboardList[i] = prevScore;
                    namesList[i] = prevName;
                }
            }
            restarted = false;
        }
    }

    public int getLeaderboard(int i)
    {
        return leaderboardList[i];
    }

    public string getName(int i)
    {
        return namesList[i];
    }

    public int getMode()
    {
        return mode;
    }

    public void setMode(int mode)
    {
        this.mode = mode;
    }

    public string printLeaderboard(int i)
    {
        return (i + ": " + leaderboardList[i]);
    }

    public void resetLeaderboard()
    {
        for (int i = 0; i < leaderboardList.Length; i++)
        {
            leaderboardList[i] = 0;
            namesList[i] = "";
        }
    }
}
