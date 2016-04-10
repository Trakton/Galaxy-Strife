using UnityEngine;
using System.Collections;

public class LoadLeaderboard : MonoBehaviour 
{
	void Awake () 
    {
        if (PlayerPrefs.HasKey("hardcoreNames")) Leaderboard.hardcoreNames = PlayerPrefsX.GetStringArray("hardcoreNames");
        else Leaderboard.hardcoreNames = new string[]
             {
                 "Higor Cavalcanti",
                 "Neon Blaster",
                 "Destroyer",
                 "Space Pirate",
                 "Blackdagger"
             };

        if (PlayerPrefs.HasKey("beginnerNames")) Leaderboard.beginnerNames = PlayerPrefsX.GetStringArray("beginnerNames");
        else Leaderboard.beginnerNames = new string[]
             {
                 "Higor Cavalcanti",
                 "Blackdagger",
                 "Galaxy Invader",
                 "Cyborg",
                 "Infector"
             };

        if (PlayerPrefs.HasKey("hardcoreScores")) Leaderboard.hardcoreScores = PlayerPrefsX.GetIntArray("hardcoreScores");
        else Leaderboard.hardcoreScores = new int[]
             {
                 1510250,
                 950025,
                 525500,
                 275250,
                 100075
             };

        if (PlayerPrefs.HasKey("beginnerScores")) Leaderboard.beginnerScores = PlayerPrefsX.GetIntArray("beginnerScores");
        else Leaderboard.beginnerScores = new int[]
             {
                 645325,
                 455255,
                 135725,
                 90225,
                 50525
             };
	}
}
