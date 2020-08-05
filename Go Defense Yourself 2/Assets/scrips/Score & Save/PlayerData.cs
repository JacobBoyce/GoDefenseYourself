using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public string[] hsNames;
    public int[] hsRounds;

    public List<HighScoreController.HighScoreEntry> highscores = new List<HighScoreController.HighScoreEntry>();


    public PlayerData(string[] name, int[] round)
    {
        hsNames = name;
        hsRounds = round;
    }

    public PlayerData (List<HighScoreController.HighScoreEntry> scores)
    {
        highscores = scores;
    }
}
