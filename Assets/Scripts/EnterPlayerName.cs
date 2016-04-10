using UnityEngine;
using System.Collections;

public class EnterPlayerName : MonoBehaviour 
{
    void OnMouseDown()
    {
        bool beatAnyScore = false;
        int i = 0;

        while (!beatAnyScore)
        {
            if (GameVariables.difficulty == "hardcore")
            {
                if (Leaderboard.hardcoreScores[i] < GameVariables.GetPlayerScore())
                {
                    Leaderboard.hardcoreScores[i] = GameVariables.GetPlayerScore();
                    Leaderboard.hardcoreNames[i] = GetPlayerName.Text;
                    beatAnyScore = true;
                }
            }

            else if (GameVariables.difficulty == "beginner")
            {
                if (Leaderboard.beginnerScores[i] < GameVariables.GetPlayerScore())
                {
                    Leaderboard.beginnerScores[i] = GameVariables.GetPlayerScore();
                    Leaderboard.beginnerNames[i] = GetPlayerName.Text;
                    beatAnyScore = true;
                }
            }

            i++;

            if (!(i < 5))
                beatAnyScore = true;
        }

        Leaderboard.Save();
       
        Application.LoadLevel(GameVariables.difficulty + "Leaderboard");
    }
}
