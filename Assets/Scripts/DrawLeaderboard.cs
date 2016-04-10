using UnityEngine;
using System.Collections;

public class DrawLeaderboard : MonoBehaviour 
{
    public bool hardcore;
    public bool beginner;
    public bool name;
    public bool score;
    public int index;

    GUIText guiText;

	void Start () 
    {
        guiText = GetComponent<GUIText>();

        if (name)
        {
            if (hardcore) guiText.text = Leaderboard.hardcoreNames[index];
            else if (beginner) guiText.text = Leaderboard.beginnerNames[index];
        }

        else if (score)
        {
            if (hardcore) guiText.text = Leaderboard.hardcoreScores[index].ToString();
            else if (beginner) guiText.text = Leaderboard.beginnerScores[index].ToString();
        }
                
	}
}
