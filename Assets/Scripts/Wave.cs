using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour
{
    static public float spawnIntervalFactor = 1;
    static public int enemiesAmountFactor = 1;

    public bool[] randomShouldUseOrigin;
    public Vector2[] origin;
    public Vector2[] randomPackRange;
    public float[] randomSpawnInterval;
    public float[] randomIntervalModifier;
    public int[] randomEnemiesPerSpawn;
    public int[] randomPerSpawnModifier;
    public string[] randomEnemies1;
    public string[] randomEnemies2;
    public string[] randomEnemies3;

    Queue<string> enemiesToSpawn = new Queue<string>();
    float spawnInterval;
    int enemiesPerSpawn;
    int perSpawnModifier;
    float intervalModifier;
    float time;
    int spawned;
    Vector2 packRange;
    Vector3 packOrigin;
    bool shouldUseOrigin;

	Ship player;

    public bool IsSpawning
    {
        get { return enemiesToSpawn.Count > 0; }
    }

	void Start () 
    {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship> ();

        string[][] allEnemies = new string[][]
        {
            randomEnemies1,
            randomEnemies2,
            randomEnemies3
        };

        string[] enemies;

        int random = Random.Range(0, 3);

        enemies = allEnemies[random];
        spawnInterval = randomSpawnInterval[random];
        intervalModifier = randomIntervalModifier[random];
        enemiesPerSpawn = randomEnemiesPerSpawn[random];
        perSpawnModifier = randomPerSpawnModifier[random];
        packRange = randomPackRange[random];
        shouldUseOrigin = randomShouldUseOrigin[random];
        
        for (int i = 0; i < enemies.Length; i++)
            enemiesToSpawn.Enqueue(enemies[i]);

        if (!shouldUseOrigin)
        {
            packOrigin = new Vector3(Random.Range(-10, 10), Random.Range(-6, 6), 0);
			Vector3 distance = player.transform.position - packOrigin;

            if (Mathf.Abs(distance.x) + packRange.x <= 4 && Mathf.Abs(distance.y) + packRange.y <= 4)
            {
                while (Mathf.Abs(distance.x) <= 4 && Mathf.Abs(distance.y) <= 4)
                {
                    packOrigin = new Vector3(Random.Range(-10, 10), Random.Range(-6, 6), 0);
					distance = player.transform.position - packOrigin;
                }
            }
        }
        else
            packOrigin = origin[0];
	}

    void Update() 
    {
        time += Time.deltaTime;

        if (player.Dead)
        {
            time = -1;
            return;
        }

        if (time >= spawnInterval * spawnIntervalFactor)
        {

            int eps = enemiesPerSpawn == 1 ? enemiesPerSpawn + 1 : enemiesPerSpawn;

            if (enemiesPerSpawn % 2 == 1)
                eps++;

            for (int i = 0; i < eps / enemiesAmountFactor; i++)
                Spawn();

            if (spawned >= perSpawnModifier)
            {
                enemiesPerSpawn++;
                spawned = 0;
            }

            spawnInterval -= intervalModifier;
        }
            
	}

    void Spawn()
{
        if (IsSpawning)
        {
            spawned += 1 * enemiesAmountFactor;

            Vector3 position;
            Vector3 distance;

            if (packRange.x + packRange.y > 0)
            {
                if (shouldUseOrigin)
                    packOrigin = origin[Random.Range(0, origin.Length)];

                    position = packOrigin + new Vector3(Random.Range(-packRange.x, packRange.x),
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

            string enemyName = enemiesToSpawn.Dequeue();
            GameObject newEnemy = ObjectsPool.GetFromPool(enemyName);
            newEnemy.transform.position = position;
            newEnemy.transform.rotation = Quaternion.identity;

			GameObject newEnemySpawn = ObjectsPool.GetFromPool(ObjectsPool.Spawns[enemyName]);
            newEnemySpawn.transform.position = position;
        }

        time = 0;
    }
}
