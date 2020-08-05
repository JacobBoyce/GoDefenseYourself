using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class HighScoreController : MonoBehaviour
{
    public Text roundText, hSTextNameList, hSRoundTextList;
    public InputField nameEntered;

    //public GameObject entryObj, scoreboardContainer, tempEntryObj;

    [System.Serializable]
    public class HighScoreEntry
    {
        public string name;
        public int highestRound;
    }

    public List<HighScoreEntry> highscores = new List<HighScoreEntry>();

    public HighScoreEntry newEntry = new HighScoreEntry();


    // Start is called before the first frame update
    void Start()
    {
        roundText.text = "Round: " + PlayerPrefs.GetInt("waveNum");


        if(!SaveSystem.InitSaveSystem(highscores))
        {
            PlayerData data = SaveSystem.LoadHighscores();
            highscores = data.highscores;
        }      
    }


    public void EnterPressed()
    {
        newEntry.name = nameEntered.text;
        newEntry.highestRound = PlayerPrefs.GetInt("waveNum");

        //check if more than 8
        if(highscores.Count == 8)
        {
            foreach(HighScoreEntry score in highscores)
            {
                if(newEntry.highestRound >= score.highestRound)
                {
                    highscores.RemoveAt(7);
                }
            }
            
        }

        highscores.Add(newEntry);
        PopulateScoreBoard();
        //save game
        //SaveSystem.SaveHighScore(names, rounds);
        SaveSystem.SaveHighScore(highscores);

    }

    public void PopulateScoreBoard()
    {
        highscores.Sort(SortByScore);

        foreach(HighScoreEntry entry in highscores)
        {
            hSTextNameList.text += entry.name + "\n";
            hSRoundTextList.text += entry.highestRound + "\n";
        }
    }

    static int SortByScore(HighScoreEntry p1, HighScoreEntry p2)
     {
        return p2.highestRound.CompareTo(p1.highestRound);
     }

     public void MainMenuButton()
     {
         SceneManager.LoadScene("MainMenu");
     }
}
