using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Starts a game mode OnMouseDown event.
/// </summary>
public class StartGame : MonoBehaviour 
{
     public float spawnIntervalFactor = 1;
     public int enemiesAmountFactor = 1;
     public float timeToNextWaveFactor = 1;
	 public Difficulty difficulty;

	void OnMouseDown () 
    {
        Wave.enemiesAmountFactor = enemiesAmountFactor;
        Wave.spawnIntervalFactor = spawnIntervalFactor;

        CicleWave.enemiesAmountFactor = enemiesAmountFactor;
        CicleWave.spawnIntervalFactor = spawnIntervalFactor;
        CicleWave.timeToNextWaveFactor = timeToNextWaveFactor;

        GameState.difficulty = difficulty;

		Score.Init ();

        SceneManager.LoadScene("Gameplay");
	}
}
