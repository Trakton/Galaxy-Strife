using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Stores inactive bullets and explosion effects in a pool for reusing them latter when needed, avoiding instantiating new ones.
/// </summary>
public class ObjectsPool : MonoBehaviour 
{
    static bool variablesLoaded;

    public GameObject bullet;
    public GameObject bulletExplosion;
    public GameObject playerSpawn;
    public GameObject playerExplosion;
    public GameObject[] enemies;
    public GameObject[] spawns;
    public GameObject[] explosions;

    static Dictionary<string, int> index = new Dictionary<string, int>();
    static Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
	static public Dictionary<int, string> Explosions { get; private set; }
	static public Dictionary<string, string> Spawns { get; private set; }

    static Queue<GameObject>[] pool;

	/// <summary>
	/// Gets the gameobjects from inspector and populates the hash dictionaries with it's entries.
	/// </summary>
    void Start()
    {
        if (!variablesLoaded)
        {
			Explosions = new Dictionary<int, string>();
			Spawns = new Dictionary<string, string>();

            index.Add("playerSpawnExplosion", 0);
            index.Add("playerDeathExplosion", 1);
            index.Add("bullet", 2);
            index.Add("bulletExplosion", 3);
            index.Add("seekerEnemy", 4);
            index.Add("walkerEnemy", 5);
            index.Add("fractionaryEnemy", 6);
            index.Add("fractionEnemy", 7);
            index.Add("missileEnemy", 8);
            index.Add("wandererEnemy", 9);
            index.Add("blueExplosion", 10);
            index.Add("redExplosion", 11);
            index.Add("purpleExplosion", 12);
            index.Add("greenExplosion", 13);
            index.Add("pinkExplosion", 14);
            index.Add("blue2Explosion", 15);
            index.Add("orangeExplosion", 16);
            index.Add("yellowExplosion", 17);
            index.Add("roxExplosion", 18);
            index.Add("tealExplosion", 19);
            index.Add("tealSpawn", 20);
            index.Add("greenSpawn", 21);
            index.Add("purpleSpawn", 22);
            index.Add("redSpawn", 23);
            index.Add("blueSpawn", 24);
            index.Add("roxSpawn", 25);

            prefabs.Add("playerSpawnExplosion", playerSpawn);
            prefabs.Add("playerDeathExplosion", playerExplosion);
            prefabs.Add("bullet", bullet);
            prefabs.Add("bulletExplosion", bulletExplosion);
            prefabs.Add("seekerEnemy", enemies[0]);
            prefabs.Add("walkerEnemy", enemies[1]);
            prefabs.Add("fractionaryEnemy", enemies[2]);
            prefabs.Add("fractionEnemy", enemies[3]);
            prefabs.Add("missileEnemy", enemies[4]);
            prefabs.Add("wandererEnemy", enemies[5]);
            prefabs.Add("blueExplosion", explosions[0]);
            prefabs.Add("redExplosion", explosions[1]);
            prefabs.Add("purpleExplosion", explosions[2]);
            prefabs.Add("greenExplosion", explosions[3]);
            prefabs.Add("pinkExplosion", explosions[4]);
            prefabs.Add("blue2Explosion", explosions[5]);
            prefabs.Add("orangeExplosion", explosions[6]);
            prefabs.Add("yellowExplosion", explosions[7]);
            prefabs.Add("roxExplosion", explosions[8]);
            prefabs.Add("tealExplosion", explosions[9]);
            prefabs.Add("tealSpawn", spawns[0]);
            prefabs.Add("greenSpawn", spawns[1]);
            prefabs.Add("purpleSpawn", spawns[2]);
            prefabs.Add("redSpawn", spawns[3]);
            prefabs.Add("blueSpawn", spawns[4]);
            prefabs.Add("roxSpawn", spawns[5]);

			Explosions.Add(0, "blueExplosion");
			Explosions.Add(1, "redExplosion");
			Explosions.Add(2, "purpleExplosion");
			Explosions.Add(3, "greenExplosion");
			Explosions.Add(4, "pinkExplosion");
			Explosions.Add(5, "blue2Explosion");
			Explosions.Add(6, "orangeExplosion");
			Explosions.Add(7, "yellowExplosion");
			Explosions.Add(8, "roxExplosion");
			Explosions.Add(9, "tealExplosion");

            Spawns.Add("seekerEnemy", "tealSpawn");
			Spawns.Add("walkerEnemy", "greenSpawn");
			Spawns.Add("fractionaryEnemy", "blueSpawn");
			Spawns.Add("fractionEnemy", "roxSpawn");
			Spawns.Add("missileEnemy", "redSpawn");
			Spawns.Add("wandererEnemy", "purpleSpawn");

            variablesLoaded = true;
         }

         pool = new Queue<GameObject>[]
         {
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
	         new Queue<GameObject>(),
        };

    }

	/// <summary>
	/// Gets an inactive object from the pool, or instantiates a new one if the pool is empty, and enables it.
	/// </summary>
	/// <returns>The gameobject from pool.</returns>
	/// <param name="name">The hash name of the desired object type.</param>
	static public GameObject GetFromPool(string name)
	{
	    GameObject gameObject = null;

	    if (pool[index[name]].Count > 0) gameObject = pool[index[name]].Dequeue();
	    else gameObject = Instantiate(prefabs[name]) as GameObject;

	    gameObject.SetActive(true);
	    return gameObject;
	}

	/// <summary>
	/// Puts an object in the pool, disabling it.
	/// </summary>
	/// <param name="name">The hash name of the desired object type.</param>
	/// <param name="gameObject">The gameobject to put in pool.</param>
	static public void PutInPool(string name, GameObject gameObject)
	{
	    gameObject.SetActive(false);
	    pool[index[name]].Enqueue(gameObject);
	}
}
