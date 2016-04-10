using UnityEngine;
using System.Collections;

public class Leaderboard : MonoBehaviour
{
    static public string[] hardcoreNames;
    static public int[] hardcoreScores;

    static public string[] beginnerNames;
    static public int[] beginnerScores;

	void Start ()
    { 
        hardcoreNames = new string[5];
        hardcoreScores = new int[5];

        beginnerNames = new string[5];
        beginnerScores = new int[5];
	}
	
	static public void Save () 
    {
        PlayerPrefsX.SetStringArray("hardcoreNames", hardcoreNames);
        PlayerPrefsX.SetIntArray("hardcoreScores", hardcoreScores);
        PlayerPrefsX.SetStringArray("beginnerNames", beginnerNames);
        PlayerPrefsX.SetIntArray("beginnerScores", beginnerScores);
	}
}
