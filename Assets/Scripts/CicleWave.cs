using UnityEngine;
using System.Collections;

public class CicleWave : MonoBehaviour 
{
    static public float spawnIntervalFactor = 1;
    static public int enemiesAmountFactor = 1;
    static public float timeToNextWaveFactor = 1;

    public string[] enemiesToSpawn;
    public int enemiesAmount;
    public float spawnInterval;
    public int enemiesPerSpawn;
    public float timeToNextWave;
    public Vector2[] origin;
    public Vector2 packRange;

    public int enemiesPerSpawnIncrement;
    public int enemiesAmountIncrement;
    public float spawnIntervalDecrease;
    public float timeToNextWaveDecrease;

    Vector2 waveRange;
    Vector3 wavePosition;
    public int enemiesSpawned;
    public float time;

	Ship player;

    [HideInInspector]
    public bool shouldPlayNextWave;

    public bool ShouldSpawn
    {
        get { return enemiesSpawned < enemiesAmount; }
    }

	void Start () 
    {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship> ();
        if (origin.Length > 0)
            wavePosition = origin[0];
        else
        {
            wavePosition = new Vector3(Random.Range(-10, 10), Random.Range(-6, 6), 0);
            Vector3 distance = player.transform.position - wavePosition;

            if (Mathf.Abs(distance.x) + packRange.x <= 4 && Mathf.Abs(distance.y) + packRange.y <= 4)
            {
                while (Mathf.Abs(distance.x) <= 4 && Mathf.Abs(distance.y) <= 4)
                {
                    wavePosition = new Vector3(Random.Range(-10, 10), Random.Range(-6, 6), 0);
					distance = player.transform.position - wavePosition;
                }
            }
        }
	}
	
	void Update () 
    {
        time += Time.deltaTime;

        if (player.Dead)
        {
            time = -1;
            return;
        }

        if (time >= spawnInterval * spawnIntervalFactor)
        {
            if (ShouldSpawn)
            {
                int eps = enemiesPerSpawn == 1 ? enemiesPerSpawn + 1 : enemiesPerSpawn;

                if (enemiesPerSpawn % 2 == 1)
                    eps++;

                for (int i = 0; i < eps / enemiesAmountFactor; i++)
                    Spawn();
            }
            else
                if (time > (spawnInterval * spawnIntervalFactor) + (timeToNextWave * timeToNextWaveFactor))
                    shouldPlayNextWave = true;

        }
	}

    void Spawn()
    {
        enemiesSpawned += 1 * enemiesAmountFactor;
        time = 0;
        Vector3 position;
        Vector3 distance;

        if (packRange.x + packRange.y > 0)
        {
            if (origin.Length > 0)
                wavePosition = origin[Random.Range(0, origin.Length)];

                position = wavePosition + new Vector3(Random.Range(-packRange.x, packRange.x),
                                                      Random.RandomRange(-packRange.y, packRange.y), 0);
        }

        else
        {
            position = new Vector3(Random.Range(-10, 10), Random.Range(-6, 6), 0);
			distance = player.transform.position - position;

            if (Mathf.Abs(distance.x) <= 4 && Mathf.Abs(distance.y) <= 4)
            {
                while (Mathf.Abs(distance.x) <= 4 && Mathf.Abs(distance.y) <= 4)
                {
                    position = new Vector3(Random.Range(-10, 10), Random.Range(-6, 6), 0);
					distance = player.transform.position - position;
                }
            }
        }

        string enemyName = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)];
        GameObject newEnemy = ObjectsPool.GetFromPool(enemyName);
        newEnemy.transform.position = position;
        newEnemy.transform.rotation = Quaternion.identity;

        GameObject newEnemySpawn = ObjectsPool.GetFromPool(ObjectsPool.Spawns[enemyName]);
        newEnemySpawn.transform.position = position; 
    }
}
