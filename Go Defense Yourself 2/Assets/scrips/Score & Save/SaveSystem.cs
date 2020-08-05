using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{
    public static void SaveHighScore(string[] names, int[] rounds)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highscores.scr";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(names, rounds);
        formatter.Serialize(stream, data);
        stream.Flush();
        stream.Close();
    }

    public static void SaveHighScore(List<HighScoreController.HighScoreEntry> scores)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highscores.scr";
        FileStream stream = new FileStream(path, FileMode.Create);
        stream.Seek(0, SeekOrigin.Begin);
        PlayerData data = new PlayerData(scores);
        formatter.Serialize(stream, data);
        stream.Flush();
        stream.Close();
    }

    public static bool InitSaveSystem(List<HighScoreController.HighScoreEntry> scores)
    {
        string path = Application.persistentDataPath + "/highscores.scr";
        if(!File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            stream.Seek(0, SeekOrigin.Begin);
            PlayerData data = new PlayerData(scores);
            formatter.Serialize(stream, data);
            stream.Flush();
            stream.Close();
            return true;
        }
        else
        {
            Debug.Log("file exists");
            return false;
        }
    }

    

    public static PlayerData LoadHighscores()
    {
        string path = Application.persistentDataPath + "/highscores.scr";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            stream.Seek(0, SeekOrigin.Begin);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Flush();
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("save file not found in " + path);
            return null;
        }
    }


}
