using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameVariables : MonoBehaviour 
{
    GUIText playerScoreGUI;
    GUIText playerHighScoreGUI;
    GUIText playerLivesGUI;
    static Dictionary<string, int> enemyScore = new Dictionary<string, int>();
    static int playerScore;
    static int playerHighScore;
    static int playerLives;
    static bool variablesLoaded;
    static public string difficulty;

    int getLiveScore = 50000;

	void Start () 
    {
        if (!variablesLoaded)
        {
            enemyScore.Add("fractionEnemy", 50);
            enemyScore.Add("seekerEnemy", 75);
            enemyScore.Add("wandererEnemy", 50);
            enemyScore.Add("walkerEnemy", 100);
            enemyScore.Add("fractionaryEnemy", 125);
            enemyScore.Add("missileEnemy", 200);
            variablesLoaded = true;
        }

        playerScore = 0;
        playerLives = 3;

        playerHighScore = difficulty == "hardcore" ? Leaderboard.hardcoreScores[0] : Leaderboard.beginnerScores[0];
	}

    void OnEnable()
    {
        playerScoreGUI = GameObject.Find("PlayerScore").GetComponent<GUIText>();
        playerHighScoreGUI = GameObject.Find("PlayerHighScore").GetComponent<GUIText>();
        playerLivesGUI = GameObject.Find("PlayerLives").GetComponent<GUIText>();
    }
	
	void Update () 
    {
        playerHighScore = playerScore > playerHighScore ? playerScore : playerHighScore;

        playerScoreGUI.text = playerScore.ToString();
        playerHighScoreGUI.text = playerHighScore.ToString();
        playerLivesGUI.text = playerLives.ToString();

        if (playerScore >= getLiveScore)
        {
            playerLives++;
            getLiveScore += 50000;
        }

	}

    static public int GetEnemyScore(string name)
    {
        return enemyScore[name];
    }

    static public int GetPlayerScore()
    {
        return playerScore;
    }

    static public void IncreasePlayerScore(int value)
    {
        playerScore += value;
    }

    static public void DecreasePlayerLives()
    {
        playerLives = Mathf.Clamp(playerLives -= 1 , 0, 9);
    }

    static public int GetPlayerLives()
    {
        return playerLives;
    }
}
