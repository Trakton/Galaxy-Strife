using UnityEngine;
using System.Collections;

/// <summary>
/// Updates the gameplay UI such as ship scores and lives.
/// </summary>
public class GameGUI : MonoBehaviour 
{
	public GameState gameState;
	public GUIText[] score;
	public GUIText[] lives;
	public GUIText highscore;

	void Update () 
	{
		foreach (Ship ship in gameState.ships) 
		{
			score [ship.id].text = ship.Score.ToString ();
			lives [ship.id].text = ship.Lives.ToString ();
		}
			
		highscore.text = gameState.Highscore.ToString();
	}
}
