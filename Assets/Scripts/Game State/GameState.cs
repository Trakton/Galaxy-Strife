using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Stores information of a current gameplay instance such as ships and enemies in scene and game difficulty.
/// </summary>
public class GameState : MonoBehaviour 
{
	static public Difficulty difficulty;

	int highscore;
	public int Highscore 
	{ 
		get { return highscore; } 
	}

	public Ship[] ships;
   
	void Start () 
    {
		highscore = difficulty == Difficulty.Hardcore? Leaderboard.hardcoreEntries[0].Score : Leaderboard.beginnerEntries[0].Score;
	}
	
	void Update () 
    {
		foreach (Ship ship in ships)
			highscore = Mathf.Max (ship.Score, Highscore);

	}

}
