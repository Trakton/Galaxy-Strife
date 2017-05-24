using UnityEngine;
using System.Collections;

/// <summary>
/// An enemy with basic behavior. Can be extended for special enemy types.
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

    SpriteRenderer renderer;
	protected Ship player;

    protected virtual void Begin()
    {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship> ();
        renderer = GetComponent<SpriteRenderer>();
    }
   
    protected virtual void SeekPlayer()
    {
		Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        direction = direction * moveSpeed * Time.deltaTime;
        GetComponent<Rigidbody2D>().velocity = direction;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11f + renderer.bounds.size.x / 2, 11 - renderer.bounds.size.x / 2),
                                         Mathf.Clamp(transform.position.y, -7f + renderer.bounds.size.y / 2, 7f - renderer.bounds.size.y / 2), 0);
    }

    protected virtual void SlowlySpawn()
    {
        colorAlpha = Mathf.Clamp(colorAlpha += Time.deltaTime * 1.5f, 0, 1);
        renderer.color = new Color(255, 255, 255, colorAlpha);
        
        if (colorAlpha >= 1)
            active = true;
    }

    protected virtual void Disable()
    {
        active = false;
        colorAlpha = 0;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, colorAlpha);
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
