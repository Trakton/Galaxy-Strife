using UnityEngine;
using System.Collections;

public class CicleWaveManager : MonoBehaviour 
{
    public int numberOfWaves;
    public int waveNumber;

	void Start () 
    {
        waveNumber = 1;
        string waveName = "CicleWave1";
        GameObject.Find(waveName).GetComponent<CicleWave>().enabled = true;
	}

	void Update () 
    {
        string waveName = "CicleWave" + waveNumber;

        CicleWave script = GameObject.Find(waveName).GetComponent<CicleWave>();
        Debug.Log(script.shouldPlayNextWave.ToString());
        if (script.shouldPlayNextWave)
        {
            Debug.Log(script.shouldPlayNextWave.ToString());
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
        GameObject.Find(waveName).GetComponent<CicleWave>().enabled = true;
    }
}
