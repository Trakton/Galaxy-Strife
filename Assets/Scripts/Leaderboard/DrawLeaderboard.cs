using UnityEngine;
using System.Collections;

/// <summary>
/// An entry in the leaderboard GUI.
/// </summary>
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
			if (hardcore) guiText.text = Leaderboard.hardcoreEntries[index].Name;
			else if (beginner) guiText.text = Leaderboard.beginnerEntries[index].Name;
        }

        else if (score)
        {
            if (hardcore) guiText.text = Leaderboard.hardcoreEntries[index].Score.ToString();
            else if (beginner) guiText.text = Leaderboard.beginnerEntries[index].Score.ToString();
        }
                
	}
}
