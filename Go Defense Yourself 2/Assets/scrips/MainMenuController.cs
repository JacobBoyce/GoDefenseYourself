using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text hSTextNameList, hSRoundTextList;

    public List<HighScoreController.HighScoreEntry> highscores = new List<HighScoreController.HighScoreEntry>();
    public void Start()
    {
        Time.timeScale = 1;

        if(!SaveSystem.InitSaveSystem(highscores))
        {
            PlayerData data = SaveSystem.LoadHighscores();
            highscores = data.highscores;
        }
    }
    
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PopulateScoreBoard()
    {
        hSTextNameList.text = "";
        hSRoundTextList.text = "";
        highscores.Sort(SortByScore);

        foreach(HighScoreController.HighScoreEntry entry in highscores)
        {
            hSTextNameList.text += entry.name + "\n";
            hSRoundTextList.text += entry.highestRound + "\n";
        }
    }

    static int SortByScore(HighScoreController.HighScoreEntry p1, HighScoreController.HighScoreEntry p2)
     {
        return p2.highestRound.CompareTo(p1.highestRound);
     }

}
