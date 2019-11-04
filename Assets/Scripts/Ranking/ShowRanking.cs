using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowRanking : MonoBehaviour
{
 
    public int numberOfPositions;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = GetRankingText();
    }

    string GetRankingText()
    {
        string rankingText = "";
        IEnumerable<KeyValuePair<string, int>> ranking = RankingManager.GetHighScores(numberOfPositions);

        int i = 1;
        foreach (KeyValuePair<string, int> position in ranking){
            rankingText += i + " - " + position.Key + ": " + position.Value + "\n";
            i++;
        }

        return rankingText;
    }
}
