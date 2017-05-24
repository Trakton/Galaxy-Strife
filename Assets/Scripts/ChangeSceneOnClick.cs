using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Changes the current scene to a specific scene name on mouse down.
/// </summary>
public class ChangeSceneOnClick : MonoBehaviour 
{
    public string nextScene = "";

    void OnMouseDown()
    {
        Leaderboard.Save();

        if (nextScene == "")
            Application.Quit();

		SceneManager.LoadScene(nextScene);
    }

}
