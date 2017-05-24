using UnityEngine;
using System.Collections;

/// <summary>
/// Friendly ship base class. Able to spawn, die and level up. Should be extended for defining moving behavior.
/// </summary>
public class Ship : MonoBehaviour 
{
	public int id;

	int score;
	public int Score 
	{ 
		get { return score; }
	}

	int lives;
	public int Lives 
	{ 
		get { return lives; } 
	}
		
	protected ParticleSystem engine;
	protected BoxCollider2D box2d;
	protected Rigidbody2D body;
	protected SpriteRenderer renderer;

	public GameObject gun;
	public float moveSpeed = 5000;

	protected float timer;
	protected float levelUpScore = 10000;
	protected int getLiveScore = 50000;

	protected Vector2 direction;

	public bool Dead { get; private set; }

	protected virtual void Start()
	{
		ResetVariables ();
		engine = GetComponentInChildren<ParticleSystem>();
		box2d = GetComponent<BoxCollider2D>();
		body = GetComponent<Rigidbody2D> ();
		renderer = GetComponent<SpriteRenderer> ();
	}

	protected virtual void Update()
	{
		if (Dead)
		{
			timer += Time.deltaTime;

			if (timer > 2)
			{
				if (Lives > 0)
					Spawn();
			} 
		}
		
		if (Score > levelUpScore)
			LevelUp();

		if (Score > getLiveScore)
			GetLive ();
	}

	protected virtual void FixedUpdate()
	{
		if (Dead)
			return;

		Move();
	}

	protected virtual void Move()
	{
		if (direction != Vector2.zero)
		{
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		}

		Vector2 force = direction * moveSpeed * Time.deltaTime;
		body.AddForce(force);

		engine.enableEmission = Mathf.Abs(body.velocity.x) + Mathf.Abs(body.velocity.y) > 0.1f ? true : false;
	}

	/// <summary>
	/// Resets the variables to a starting state for a fresh game.
	/// </summary>
	protected virtual void ResetVariables()
	{
		Dead = false;
		timer = 0;
		score = 0;
		lives = 3;
	}

	/// <summary>
	/// Respawns the ship, enabling it's components.
	/// </summary>
	protected virtual void Spawn()
	{
		foreach (MouseDrivenGun gun in GetComponentsInChildren<MouseDrivenGun>())
			gun.enabled = true;

		ExplosionGenerator.SpawnPlayer (transform.position);
		renderer.enabled = true;
		box2d.enabled = true;
		engine.Play();
		Dead = false;
		timer = 0;
	}

	/// <summary>
	/// When player reaches certain score, it wins a life.
	/// </summary>
	protected virtual void GetLive()
	{
		lives++;
		getLiveScore += 50000;
	}

	/// <summary>
	/// Upgrades the ship by adding a new gun.
	/// </summary>
	protected virtual void LevelUp()
	{
		GameObject newGun = Instantiate(gun, transform.position, Quaternion.identity) as GameObject;
		newGun.transform.parent = transform;
		newGun.GetComponent<Gun> ().shooter = this;

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
		renderer.enabled = false;
		lives = Mathf.Clamp (Lives - 1, 0, 6);
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

	/// <summary>
	/// Increases the ship score.
	/// </summary>
	/// <param name="amount">How much to increase.</param>
	public void IncreaseScore(int amount)
	{
		score += amount;
	}
}
