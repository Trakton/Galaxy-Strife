using UnityEngine;

/// <summary>
/// Loads the leaderboard from computer memory using player prefs or creates a default one if there is nothing saved.
/// </summary>
public class LoadLeaderboard : MonoBehaviour 
{
	void Awake () 
    {
		DefaultLeaderboard.Init ();
	
		if (PlayerPrefs.HasKey ("hardcoreNames"))
			Leaderboard.hardcoreEntries = LoadEntries ("hardcore");
		else
			Leaderboard.hardcoreEntries = DefaultLeaderboard.hardcoreEntries;

		if (PlayerPrefs.HasKey ("beginnerNames"))
			Leaderboard.beginnerEntries = LoadEntries ("beginner");
		else 
			Leaderboard.beginnerEntries = DefaultLeaderboard.beginnerEntries;
	}

	LeaderboardEntry[] LoadEntries(string difficulty)
	{
		string[] names = PlayerPrefsX.GetStringArray(difficulty+"Names");
		int[] scores = PlayerPrefsX.GetIntArray(difficulty+"Scores");
	
		LeaderboardEntry[] entries = new LeaderboardEntry[5];

		for(int i = 0; i < 5; i++)
			entries [i] = new LeaderboardEntry (names [i], scores [i]);

		return entries;
	}
}
