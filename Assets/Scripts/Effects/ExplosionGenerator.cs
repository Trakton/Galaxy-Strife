using UnityEngine;

/// <summary>
/// Manages the explosion effects of the game.
/// </summary>
public static class ExplosionGenerator 
{
	/// <summary>
	/// Generates an bullet death type explosion.
	/// </summary>
	/// <param name="position">The vector3 position of the explosion.</param>
	static public void ExplodeBullet(Vector3 position)
	{
		GameObject explosion = ObjectsPool.GetFromPool("bulletExplosion");
		explosion.transform.position = position;
	}

	/// <summary>
	/// Generates an enemy death type explosion.
	/// </summary>
	/// <param name="position">The vector3 position of the explosion.</param>
	static public void ExplodeEnemy(Vector3 position)
	{
		int random = Random.Range (0, ObjectsPool.Explosions.Count);
		GameObject explosion = ObjectsPool.GetFromPool(ObjectsPool.Explosions[random]);
		explosion.transform.position = position;
	}

	/// <summary>
	/// Generates an player spawn type explosion.
	/// </summary>
	/// <param name="position">The vector3 position of the explosion.</param>
	static public void SpawnPlayer(Vector3 position)
	{
		GameObject spawnExplosion = ObjectsPool.GetFromPool("playerSpawnExplosion");
		spawnExplosion.transform.position = position;
	}

	/// <summary>
	/// Generates an player death type explosion.
	/// </summary>
	/// <param name="position">The vector3 position of the explosion.</param>
	static public void ExplodePlayer(Vector3 position)
	{
		GameObject deathExplosion = ObjectsPool.GetFromPool("playerDeathExplosion");
		deathExplosion.transform.position = position;
	}
}
