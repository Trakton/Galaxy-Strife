using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour 
{
    public Wave[] waves;

    Queue<Wave> wavesToSpawn;
    Queue<Wave> spawnedWaves;

    GameObject currentWave;
    int waveNumber = 0;

	void Start () 
    {
        wavesToSpawn = new Queue<Wave>();

        for (int i = 0; i < waves.Length; i++)
            wavesToSpawn.Enqueue(waves[i]);
      
        Spawn();
	}
	
	void Update () 
    {
        string waveName = "Wave" + waveNumber +"(Clone)";

        if (!GameObject.Find(waveName).GetComponent<Wave>().IsSpawning)
        {
            Spawn();
        }
	}

    void Spawn()
    {
        if (wavesToSpawn.Count > 0)
        {
            string waveName = "Wave" + waveNumber + "(Clone)";
            Destroy(GameObject.Find(waveName));
            Instantiate(wavesToSpawn.Dequeue(), Vector3.zero, Quaternion.identity);
            waveNumber++;

        }
        else
        {
            GameObject.Find("CicleWaveManager").GetComponent<CicleWaveManager>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
