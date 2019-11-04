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
        if (ranking == null)
            LoadRanking();

        //add scores to ranking
        AddOrUpdate(ranking, player1, score1);
        AddOrUpdate(ranking, player2, score2);

        //call SaveRanking
        SaveRanking();
    }

    static void AddOrUpdate(ScoreDictionary dict, string key, int newValue)
    {
        //player already has score
        if (dict.ContainsKey(key)) {
            //update value only if new score is higher
            if(dict[key] < newValue)
                dict[key] = newValue;
        }
        else
        {
            //first score recorded for player
            dict.Add(key, newValue);
        }
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
