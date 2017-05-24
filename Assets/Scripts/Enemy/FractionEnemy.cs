using UnityEngine;
using System.Collections;

/// <summary>
/// Special enemy type with circle movement.
/// </summary>
public class FractionEnemy : Enemy 
{
    public float rotateSpeed;
    float aceleration;

	protected override void Start ()
    {
		base.Start ();
        rotateSpeed = Random.Range(rotateSpeed * 3 / 4, rotateSpeed);
        moveSpeed = Random.Range(moveSpeed * 3 / 4, moveSpeed);
	}

	/// <summary>
	/// Moves to the player while orbiting around itself.
	/// </summary>
	protected override void SeekPlayer () 
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
        base.SeekPlayer();
	}
}
