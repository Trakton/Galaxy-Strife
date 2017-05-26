using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Calculates the risk of being in a position based on enemies distance, map edges and enemy spanwers.
/// </summary>
public class Risk 
{
	Dictionary<string, float> enemies;
	Dictionary<Vector2, float> spawners;
	Vector2 leftEdge;
	Vector2 rightEdge;
	Vector2 upEdge;
	Vector2 downEdge;

	float enemyRiskModifier = 100.0f;
	float spawnerRiskModifier = 1.0f;
	float edgeRiskModifier = 5.0f;

	float spawnerCumulativeRisk = 1.0f;

	public Risk()
	{
		SetEnemyRisk ();
		SetSpawnerRisk ();
		SetEdgeRisk ();
	}

	/// <summary>
	/// Calculate the risk of a position by the exponential inverse of it's distance to spawners, edges and enemies.
	/// </summary>
	/// <param name="position">The desired vector2 position.</param>
	public float Calculate(Vector2 position)
	{
		float risk = 0.0f;

		risk += GetEnemyRisk (position);
	//	risk += GetSpawnerRisk (position);
		risk += GetEdgeRisk (position);

		return risk;
	}

	/// <summary>
	/// Sets a distinct risk for each enemy type.
	/// </summary>
	void SetEnemyRisk()
	{
		enemies = new Dictionary<string, float> ();

		enemies.Add("fractionEnemy", 1.0f);
		enemies.Add("seekerEnemy", 1.0f);
		enemies.Add("wandererEnemy", 1.0f);
		enemies.Add("walkerEnemy", 1.0f);
		enemies.Add("fractionaryEnemy", 1.0f);
		enemies.Add("missileEnemy", 1.0f);
	}

	/// <summary>
	/// Get possible spawn positions from all enemy wave types and sets a cumulative risk for them.
	/// </summary>
	void SetSpawnerRisk()
	{
		spawners = new Dictionary<Vector2, float> ();

		GameObject[] cicleWavesObj = GameObject.FindGameObjectsWithTag ("CicleWave");
		CicleWave[] cicleWaves = new CicleWave[cicleWavesObj.Length];

		for (int i = 0; i < cicleWavesObj.Length; i++)
			cicleWaves [i] = cicleWavesObj [i].GetComponent<CicleWave> ();
		
		foreach (CicleWave wave in cicleWaves)
			foreach (Vector2 origin in wave.origin)
				AddSpawner (origin);

		WaveManager waveManager = GameObject.Find ("WaveManager").GetComponent<WaveManager> ();

		foreach (Wave wave in waveManager.waves)
			foreach (Vector2 origin in wave.origin)
				AddSpawner (origin);
	}

	/// <summary>
	/// Gets the map edges positions from 2d stage colliders and sets a risk for them.
	/// </summary>
	void SetEdgeRisk()
	{
		Transform left = GameObject.Find ("2DLeftCollider").transform;
		Transform up =  GameObject.Find ("2DUpCollider").transform;
		Transform down =  GameObject.Find ("2DDownCollider").transform;
		Transform right =  GameObject.Find ("2DRightCollider").transform;
		leftEdge = new Vector2 (left.position.x, left.position.y);
		rightEdge = new Vector2 (right.position.x, right.position.y);
		upEdge = new Vector2 (up.position.x, up.position.y);
		downEdge = new Vector2 (down.position.x, down.position.y);
	}

	void AddSpawner(Vector2 spawner)
	{
		if (spawners.ContainsKey (spawner))
			spawners [spawner] += spawnerCumulativeRisk;
		else
			spawners.Add (spawner, 1.0f);
	}

	/// <summary>
	/// Calculates the risk of a position based on enemies.
	/// </summary>
	/// <returns>The enemy risk.</returns>
	float GetEnemyRisk(Vector2 position)
	{
		float risk = 0.0f;

		foreach (Enemy enemy in GameState.Enemies.InScene.Values) 
		{
			Vector2 target = new Vector2 (enemy.transform.position.x, enemy.transform.position.z);
			float distance = (position - target).magnitude;
			risk += Mathf.Pow (this.enemies [enemy.Name] * enemyRiskModifier, 1.0f/distance);
		}

		return risk;
	}

	/// <summary>
	/// Calculates the risk of a position based on spawners.
	/// </summary>
	/// <returns>The enemy risk.</returns>
	float GetSpawnerRisk(Vector2 position)
	{
		float risk = 0.0f;

		foreach (KeyValuePair<Vector2, float> entry in spawners) 
		{
			Vector2 spawner = entry.Key;
			float magnitude = entry.Value;

			float distance = (position -  spawner).magnitude;
			risk += Mathf.Pow (magnitude * spawnerRiskModifier, 1.0f / distance);
		}

		return risk;
	}

	/// <summary>
	/// Calculates the risk of a position based on map edges.
	/// </summary>
	/// <returns>The enemy risk.</returns>
	float GetEdgeRisk(Vector2 position)
	{
		float risk = 0.0f;

		float leftDistance = Mathf.Abs (leftEdge.x - position.x);
		float rightDistance = Mathf.Abs (rightEdge.x - position.x);
		float upDistance = Mathf.Abs (upEdge.y - position.y);
		float downDistance = Mathf.Abs (downEdge.y - position.y);

		risk += Mathf.Pow (edgeRiskModifier, 1.0f / leftDistance);
		risk += Mathf.Pow (edgeRiskModifier, 1.0f / rightDistance);
		risk += Mathf.Pow (edgeRiskModifier, 1.0f / upDistance);
		risk += Mathf.Pow (edgeRiskModifier, 1.0f / downDistance);

		return risk;
	}
}
