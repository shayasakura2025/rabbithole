using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int currentScore;
    public int highestScore;
    public bool tutorial;
    // Start is called before the first frame update
    public GameData(int currentScore, int highestScore, bool tutorial)
    {
        this.currentScore = currentScore;
        this.highestScore = highestScore;
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
}
