using UnityEngine;
using System.Collections;

/// <summary>
/// An enemy with basic behavior. Can be extended for special enemy types and behaviors.
/// </summary>
public class Enemy : MonoBehaviour
{
	/// <summary>
	/// Gets the original enemy name, excluding (Clone) tag.
	/// </summary>
	public string Name 
	{ 
		get 
		{ 
			return name.Remove(name.Length - ("(Clone)").Length); 
		} 
	}

    public float moveSpeed;
    protected bool active;
	private float colorAlpha;

	protected Rigidbody2D body;
    protected SpriteRenderer renderer;
	protected Ship player;

	/// <summary>
	/// Initializes variables.
	/// </summary>
    protected virtual void Start()
    {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship> ();
        renderer = GetComponent<SpriteRenderer>();
		body = GetComponent<Rigidbody2D> ();
    }

	/// <summary>
	/// Slowly fades the enemy in when spawning, and start seeking player when completely spawned.
	/// </summary>
	protected virtual void Update()
	{
		if (!active)
		{
			SlowlySpawn();
			return;
		}

		SeekPlayer ();
	}
		
	/// <summary>
	/// Traces a path in a line straight to the player. Can be overrided to define custom moving patterns.
	/// </summary>
    protected virtual void SeekPlayer()
    {
		Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        direction = direction * moveSpeed * Time.deltaTime;
        body.velocity = direction;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11f + renderer.bounds.size.x / 2, 11 - renderer.bounds.size.x / 2),
                                         Mathf.Clamp(transform.position.y, -7f + renderer.bounds.size.y / 2, 7f - renderer.bounds.size.y / 2), 0);
    }

	/// <summary>
	/// Fades the enemy in the screen.
	/// </summary>
    protected virtual void SlowlySpawn()
    {
        colorAlpha = Mathf.Clamp(colorAlpha += Time.deltaTime * 1.5f, 0, 1);
        renderer.color = new Color(255, 255, 255, colorAlpha);
        
        if (colorAlpha >= 1)
            active = true;
    }

	/// <summary>
	/// Generates an explosion on enemy spawn.
	/// </summary>
	public virtual void Spawn(Vector3 position)
	{
		transform.rotation = Quaternion.identity;
		transform.position = position;
		ExplosionGenerator.SpawnEnemy (Name, transform.position);
	}


	/// <summary>
	/// Disable this instance.
	/// </summary>
    protected virtual void OnDisable()
    {
        active = false;
        colorAlpha = 0;
        renderer.color = new Color(255, 255, 255, colorAlpha);
    }

	/// <summary>
	/// Generates an explosion at enemy position and insert it in the pool of inactive objects.
	/// </summary>
	public void Explode()
	{
		ExplosionGenerator.ExplodeEnemy (transform.position);
		ObjectsPool.PutInPool(Name, this.gameObject);
	}
}
