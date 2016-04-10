using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    static public Dictionary<int, string> explosionsDic = new Dictionary<int, string>();
    static public Dictionary<string, string> spawnsDic = new Dictionary<string, string>();

    static Queue<GameObject>[] pool;


     void Start()
     {
         if (!variablesLoaded)
         {
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

             explosionsDic.Add(0, "blueExplosion");
             explosionsDic.Add(1, "redExplosion");
             explosionsDic.Add(2, "purpleExplosion");
             explosionsDic.Add(3, "greenExplosion");
             explosionsDic.Add(4, "pinkExplosion");
             explosionsDic.Add(5, "blue2Explosion");
             explosionsDic.Add(6, "orangeExplosion");
             explosionsDic.Add(7, "yellowExplosion");
             explosionsDic.Add(8, "roxExplosion");
             explosionsDic.Add(9, "tealExplosion");

             spawnsDic.Add("seekerEnemy", "tealSpawn");
             spawnsDic.Add("walkerEnemy", "greenSpawn");
             spawnsDic.Add("fractionaryEnemy", "blueSpawn");
             spawnsDic.Add("fractionEnemy", "roxSpawn");
             spawnsDic.Add("missileEnemy", "redSpawn");
             spawnsDic.Add("wandererEnemy", "purpleSpawn");

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

     static public GameObject GetFromPool(string name)
     {
         GameObject gameObject = null;

         if (pool[index[name]].Count > 0) gameObject = pool[index[name]].Dequeue();
         else gameObject = Instantiate(prefabs[name]) as GameObject;

         gameObject.SetActive(true);
         return gameObject;
     }

     static public void PutInPool(string name, GameObject gameObject)
     {
         gameObject.SetActive(false);
         pool[index[name]].Enqueue(gameObject);
     }

}
