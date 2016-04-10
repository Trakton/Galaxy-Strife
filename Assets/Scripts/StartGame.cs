using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour 
{
     public float spawnIntervalFactor = 1;
     public int enemiesAmountFactor = 1;
     public float timeToNextWaveFactor = 1;
     public string difficulty;

	void OnMouseDown () 
    {
        Wave.enemiesAmountFactor = enemiesAmountFactor;
        Wave.spawnIntervalFactor = spawnIntervalFactor;

        CicleWave.enemiesAmountFactor = enemiesAmountFactor;
        CicleWave.spawnIntervalFactor = spawnIntervalFactor;
        CicleWave.timeToNextWaveFactor = timeToNextWaveFactor;

        GameVariables.difficulty = difficulty;

        Application.LoadLevel("Gameplay");
	}
}
