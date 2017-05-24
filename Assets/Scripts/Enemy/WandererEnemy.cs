using UnityEngine;
using System.Collections;

/// <summary>
/// Special enemy type that is unaware of player position. Just rotates randomly around the map.
/// </summary>
public class WandererEnemy : Enemy 
{
    Vector2 direction;
    float elapsedTime;
    float directionChangeTime;

	protected override void Start () 
    {
        base.Start();
        moveSpeed = Random.Range(moveSpeed - moveSpeed / 5f, moveSpeed + moveSpeed / 5f);
        directionChangeTime = Random.Range(3, 6);
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
	}

	/// <summary>
	/// Ignores player position and rotates randomly around the map.
	/// </summary>
	protected override void SeekPlayer () 
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > directionChangeTime)
        {
            direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            elapsedTime = 0;
            directionChangeTime = Random.Range(3, 6);
        }

        if (transform.position.x < -11f + GetComponent<Renderer>().bounds.size.x / 2 ||
            transform.position.x > 11f - GetComponent<Renderer>().bounds.size.x / 2)
            direction.x *= -1;

        if (transform.position.y < -7f + GetComponent<Renderer>().bounds.size.y / 2 ||
           transform.position.y > 7f - GetComponent<Renderer>().bounds.size.y / 2)
            direction.y *= -1;

        body.velocity = direction * moveSpeed * Time.deltaTime;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11f + GetComponent<Renderer>().bounds.size.x / 2, 11 - GetComponent<Renderer>().bounds.size.x / 2),
                                        Mathf.Clamp(transform.position.y, -7f + GetComponent<Renderer>().bounds.size.y / 2, 7f - GetComponent<Renderer>().bounds.size.y / 2), 0);
	}
}
