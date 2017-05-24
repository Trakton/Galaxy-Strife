using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Keeps the game in a infinite loop of incresing dificulty repeated waves.
/// </summary>
public class CicleWaveManager : MonoBehaviour 
{
    public int numberOfWaves;
    public int waveNumber;

	GameObject[] wavesObj;
	Dictionary<string, CicleWave> waves;

	void Start () 
    {
		wavesObj = GameObject.FindGameObjectsWithTag ("CicleWave");
		waves = new Dictionary<string, CicleWave> ();

		for (int i = 0; i < wavesObj.Length; i++)
			waves.Add (wavesObj [i].name, wavesObj [i].GetComponent<CicleWave> ());

        waveNumber = 1;
        string waveName = "CicleWave1";
	
        waves[waveName].enabled = true;
	}

	void Update () 
    {
        string waveName = "CicleWave" + waveNumber;

		CicleWave script = waves [waveName];

        if (script.shouldPlayNextWave)
        {
            script.shouldPlayNextWave = false;
            script.enemiesSpawned = 0;
            script.time = 0;

            script.enemiesAmount += script.enemiesAmountIncrement;
            script.enemiesPerSpawn += script.enemiesPerSpawnIncrement;
            script.spawnInterval -= script.spawnIntervalDecrease;
            script.timeToNextWave -= script.timeToNextWaveDecrease;
            script.enabled = false;

            Spawn();
        }
	}

    void Spawn()
    {
        
        waveNumber = Random.Range(1, numberOfWaves + 1);
        string waveName = "CicleWave" + waveNumber;
        waves[waveName].enabled = true;
    }
}
