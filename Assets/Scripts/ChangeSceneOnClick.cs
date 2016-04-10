using UnityEngine;
using System.Collections;

public class ChangeSceneOnClick : MonoBehaviour 
{
    public string nextScene = "";

    void OnMouseDown()
    {
        Leaderboard.Save();

        if (nextScene == "")
            Application.Quit();

        Application.LoadLevel(nextScene);
    }

}
