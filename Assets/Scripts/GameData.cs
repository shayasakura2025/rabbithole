using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int currentScore;
    public int highestScore;
    public int[] leaderboardList = new int[10];
    public bool tutorial;
    // Start is called before the first frame update
    public GameData(int currentScore, int highestScore, bool tutorial)
    {
        this.currentScore = currentScore;
        this.highestScore = highestScore;
        resetLeaderboard();
        this.tutorial = tutorial;
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

    public void setHighestScore(int highest)
    {
        if (highest > highestScore)
        {
            highestScore = highest;
        }
    }

    public void changeLeaderboard(int score)
    {
        if (score <= leaderboardList[9])
        {
            Debug.Log("No change to leaderboard");
        }
        else
        {
            Debug.Log("Changing leaderboard");
            bool replaced = false;
            int prevScore = 0;
            int thisScore = 0;
            for (int i = 0; i < leaderboardList.Length; i++)
            {
                if (score > leaderboardList[i] && replaced == false)
                {
                    thisScore = leaderboardList[i];
                    leaderboardList[i] = score;
                    replaced = true;
                }
                else if (replaced == true)
                {
                    prevScore = thisScore;
                    thisScore = leaderboardList[i];
                    leaderboardList[i] = prevScore;
                }
            }
        }
    }

    public int getLeaderboard(int i)
    {
        return leaderboardList[i];
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
        }
    }
}
