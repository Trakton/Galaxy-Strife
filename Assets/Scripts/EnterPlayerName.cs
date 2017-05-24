using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

/// <summary>
/// Shows on gameover screen. Updates the leaderboard with new ship scores.
/// </summary>
public class EnterPlayerName : MonoBehaviour 
{
	GameState gameState;

	void Start()
	{
		gameState = GameObject.FindGameObjectWithTag ("GameState").GetComponent<GameState> ();
	}

    void OnMouseDown()
    {
		if (GameState.difficulty == Difficulty.Beginner) {
			int originalSize = Leaderboard.beginnerEntries.Length;
			int newSize = Leaderboard.beginnerEntries.Length + gameState.ships.Length;

			LeaderboardEntry[] entries = new LeaderboardEntry[newSize];

			for (int i = 0; i < originalSize; i++)
				entries [i] = Leaderboard.beginnerEntries [i];

			for (int i = originalSize; i < newSize; i++)
				entries [i] = new LeaderboardEntry (GetPlayerName.Text, gameState.ships [i - originalSize].Score);

			Array.Sort (entries);

			for (int i = 0; i < originalSize; i++)
				Leaderboard.beginnerEntries [i] = entries [i];
		} 
		else if (GameState.difficulty == Difficulty.Hardcore) {
			int originalSize = Leaderboard.hardcoreEntries.Length;
			int newSize = Leaderboard.hardcoreEntries.Length + gameState.ships.Length;

			LeaderboardEntry[] entries = new LeaderboardEntry[newSize];

			for (int i = 0; i < originalSize; i++)
				entries [i] = Leaderboard.hardcoreEntries [i];

			for (int i = originalSize; i < newSize; i++)
				entries [i] = new LeaderboardEntry (GetPlayerName.Text, gameState.ships [i - originalSize].Score);

			Array.Sort (entries);

			for (int i = 0; i < originalSize; i++)
				Leaderboard.hardcoreEntries [i] = entries [i];
		}

        Leaderboard.Save();
       
        SceneManager.LoadScene(GameState.difficulty + "Leaderboard");
    }
}
