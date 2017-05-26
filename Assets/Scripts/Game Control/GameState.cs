using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Stores information of a current gameplay instance such as ships and enemies in scene and game difficulty.
/// </summary>
public class GameState : MonoBehaviour 
{
	static public Difficulty difficulty;

	static EnemyManager enemies;
	/// <summary>
	/// Gets the enemy manager for the gameplay instance. Has information about live enemies stored.
	/// </summary>
	static public EnemyManager Enemies 
	{
		get { return enemies; }
	}

	int highscore;
	/// <summary>
	/// Gets the current in game highscore.
	/// </summary>
	public int Highscore 
	{ 
		get { return highscore; } 
	}

	public Ship[] ships;
	bool raisedGameover;

	void Start () 
    {
		raisedGameover = false;
		enemies = new EnemyManager (1000);
		highscore = difficulty == Difficulty.Hardcore? Leaderboard.hardcoreEntries[0].Score : Leaderboard.beginnerEntries[0].Score;
	}
	
	void Update () 
    {
		bool gameEnded = true;
		foreach (Ship ship in ships) 
		{
			if (ship.Lives > 0)
				gameEnded = false;
			
			highscore = Mathf.Max (ship.Score, Highscore);
		}

		if (gameEnded && !raisedGameover)
		{
			raisedGameover = true;
			SceneManager.LoadScene ("Gameover", LoadSceneMode.Additive);
		}
	}

}
