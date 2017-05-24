using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A bullet raises OnTriggerEnter2D events on StageCollider or Enemies to explode them.
/// </summary>
public class Bullet : MonoBehaviour 
{
	/// <summary>
	/// Raises the trigger enter 2d event, exploding enemies hitted by bullet.
	/// </summary>
	/// <param name="collider">The Collider2d of the object hitted by bullet.</param>
    void OnTriggerEnter2D(Collider2D collider)
    {
		if (collider.tag == "StageCollider") 
		{
			ExplodeBullet ();
		}
        else if (collider.tag == "Enemy")
        {
			KillBullet ();
			ExplodeEnemy (collider.gameObject);
        }
    }

	/// <summary>
	/// Generates an explosion at bullet position and insert it in the pool of inactive objects.
	/// </summary>
	void ExplodeBullet()
	{
		ExplosionGenerator.ExplodeBullet (transform.position);
		KillBullet ();
	}

	/// <summary>
	/// Inserts the gameobject in the pool of inactive objects.
	/// </summary>
	void KillBullet()
	{
		ObjectsPool.PutInPool("bullet", this.gameObject);
	}

	/// <summary>
	/// Generates an explosion at enemy position, kills enemy and increases player score.
	/// </summary>
	/// <param name="enemy">The enemy hitted by bullet gameobject.</param>
	void ExplodeEnemy(GameObject enemy)
	{
		Enemy script = enemy.GetComponent<Enemy> ();
		script.Explode ();
		GameVariables.IncreasePlayerScore(GameVariables.GetEnemyScore(script.Name));
	}
}
