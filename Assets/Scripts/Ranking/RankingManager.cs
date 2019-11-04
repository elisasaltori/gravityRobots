using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Loads, updates and saves ranking
/// </summary>
public static class RankingManager
{

    private static string gameDataProjectFilePath = "ranking.json";
    static ScoreDictionary ranking;

    //Load ranking from file (if file is missing, default ranking is loaded)
    //returns loaded ranking objected
    public static ScoreDictionary LoadRanking()
    {
        string path = Application.dataPath;
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, gameDataProjectFilePath);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            ranking = JsonUtility.FromJson<ScoreDictionary>(dataAsJson);
        }
        else
        {
            //default ranking
            ranking = new ScoreDictionary();
        }

        return ranking;
    }

    //Saves current ranking to file
    public static void SaveRanking()
    {
        if (ranking == null)
            LoadRanking();

        string dataAsJson = JsonUtility.ToJson(ranking);

        //create Folder
        if (!Directory.Exists(Application.dataPath))
        {

            Directory.CreateDirectory(Application.dataPath);
        }

        string path = Application.dataPath;

        string filePath = System.IO.Path.Combine(Application.persistentDataPath, gameDataProjectFilePath);

        File.WriteAllText(filePath, dataAsJson);
    }

    //Updates ranking using finalScore and the name given
    public static void UpdateRanking(string player1, int score1, string player2, int score2)
    {
        //add scores to ranking
        ranking.Add(score1, player1);
        ranking.Add(score2, player2);
        //call SaveRanking
        SaveRanking();
    }


    //Resets ranking to original state
    public static void ResetRanking()
    {
        ranking = null;

        string path = Application.dataPath;

        string filePath = System.IO.Path.Combine(Application.persistentDataPath, gameDataProjectFilePath);
        File.Delete(filePath);

        SaveRanking();
    }
}
