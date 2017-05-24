using UnityEngine;
using System.Collections;

/// <summary>
/// Friendly ship base class. Able to spawn, die and level up. Should be extended for defining moving behavior.
/// </summary>
public class Ship : MonoBehaviour 
{
	protected ParticleSystem engine;
	protected BoxCollider2D box2d;
	protected Rigidbody2D body;

	public GameObject gun;
	public float moveSpeed = 10;

	protected float timer;
	protected float levelUpScore = 10000;

	protected Vector2 direction;

	public bool Dead { get; private set; }

	protected virtual void Start()
	{
		Dead = false;
		timer = 0;
		engine = GetComponentInChildren<ParticleSystem>();
		box2d = GetComponent<BoxCollider2D>();
		body = GetComponent<Rigidbody2D> ();
	}

	protected virtual void Update()
	{
		if (GameVariables.GetPlayerScore() > levelUpScore)
			LevelUp();
	}

	protected virtual void FixedUpdate()
	{
		if (Dead)
			return;

		Move();
	}

	protected virtual void Move()
	{ }

	/// <summary>
	/// Respawns the ship, enabling it's components.
	/// </summary>
	protected virtual void Spawn()
	{
		foreach (MouseDrivenGun gun in GetComponentsInChildren<MouseDrivenGun>())
			gun.enabled = true;

		ExplosionGenerator.SpawnPlayer (transform.position);
		GetComponent<Renderer>().enabled = true;
		box2d.enabled = true;
		engine.Play();
		Dead = false;
		timer = 0;
	}

	/// <summary>
	/// Upgrades the ship by adding a new gun.
	/// </summary>
	protected virtual void LevelUp()
	{
		GameObject newGun = Instantiate(gun, transform.position, Quaternion.identity) as GameObject;
		newGun.transform.parent = transform;

		MouseDrivenGun[] playerGuns = GetComponentsInChildren<MouseDrivenGun>();

		float startAngle = playerGuns.Length * -2;
		float angleIncrease = playerGuns.Length;

		for (int i = 0; i < playerGuns.Length; i++)
		{
			playerGuns[i].angleOffset = startAngle + i * playerGuns.Length;
			playerGuns[i].time = 0f;
		}

		levelUpScore *= 10;
	}

	/// <summary>
	/// Kills the ship, disabling it's components, killing all enemies and generating an explosion.
	/// </summary>
	protected virtual void Die()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (MouseDrivenGun gun in GetComponentsInChildren<MouseDrivenGun>())
			gun.enabled = false;

		foreach (GameObject enemy in enemies)
			enemy.GetComponent<Enemy> ().Explode ();

		ExplosionGenerator.ExplodePlayer (transform.position);
		GetComponent<Renderer>().enabled = false;
		GameVariables.DecreasePlayerLives();
		box2d.enabled = false;
		engine.Stop();
		Dead = true;
	}

	/// <summary>
	/// Explodes the ship on enemy hit.
	/// </summary>
	/// <param name="collider">The trigger event collider.</param>
	protected virtual void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Enemy")
		{
			Die();
		}
	}
}
