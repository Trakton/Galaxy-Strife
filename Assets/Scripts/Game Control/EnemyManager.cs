using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Manages enemy spawn and unspawn and stores information about live enemies in the map.
/// </summary>
static public class EnemyManager
{
	static Dictionary<int, Enemy> inScene;
	/// <summary>
	/// Returns a list of all active enemies in the map.
	/// </summary>
	static public Dictionary<int, Enemy> InScene 
	{ 
		get { return inScene; } 
	}

	static int capacity;
	static int index;

	/// <summary>
	/// Creates an hash table with specified capacity for storing enemy information.
	/// </summary>
	/// <param name="capacity">The hash table capacity.</param>
	static public void Start(int hashTableCapacity)
	{
		capacity = hashTableCapacity;
		inScene = new Dictionary<int, Enemy> ();
	}

	/// <summary>
	/// Spawn the specified enemy at position, storing him in a enemy array.
	/// </summary>
	/// <param name="enemy">The formal name of the desired enemy.</param>
	/// <param name="position">The vector3 position to spawn.</param>
	static public void Spawn(string enemy, Vector3 position)
	{
		Enemy newEnemy = ObjectsPool.GetFromPool(enemy).GetComponent<Enemy>();
		newEnemy.Spawn (position, index);
		inScene.Add (index, newEnemy);
		index++;
		if (index == capacity)
			index = 0;
	}

	/// <summary>
	/// Explodes an enemy and removes it from the hash.
	/// </summary>
	/// <param name="id">The enemy id.</param>
	static public void Kill(int id)
	{
		inScene [id].Explode ();
		inScene.Remove (id);
	}
}
