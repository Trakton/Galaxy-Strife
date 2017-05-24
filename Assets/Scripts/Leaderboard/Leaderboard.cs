using UnityEngine;
using System.Collections;

/// <summary>
/// Stores leaderboard entries and saves then in computer memory.
/// </summary>
public class Leaderboard : MonoBehaviour
{
	static public LeaderboardEntry[] beginnerEntries;
	static public LeaderboardEntry[] hardcoreEntries;

	/// <summary>
	/// Converts the entries into simple string and int arrays to be saved easily in user prefs.
	/// </summary>
	static public void Save () 
    {
		string[] hardcoreNames = new string[5];
		int[] hardcoreScores = new int[5];

		string[] beginnerNames = new string[5];
		int[] beginnerScores= new int[5];

		for (int i = 0; i < beginnerEntries.Length; ++i) 
		{
			beginnerNames [i] = beginnerEntries [i].Name;
			beginnerScores [i] = beginnerEntries [i].Score;
		}

		for (int i = 0; i < hardcoreEntries.Length; ++i) 
		{
			hardcoreNames [i] = hardcoreEntries [i].Name;
			hardcoreScores [i] = hardcoreEntries [i].Score;
		}

        PlayerPrefsX.SetStringArray("hardcoreNames", hardcoreNames);
        PlayerPrefsX.SetIntArray("hardcoreScores", hardcoreScores);
        PlayerPrefsX.SetStringArray("beginnerNames", beginnerNames);
        PlayerPrefsX.SetIntArray("beginnerScores", beginnerScores);
	}
}
