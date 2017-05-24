using UnityEngine;
using System.Collections;

/// <summary>
/// Seekers move in a line straight to the player direction.
/// </summary>
public class SeekerEnemy : Enemy 
{
	/// <summary>
	/// Picks a random move speed for allowing some variation.
	/// </summary>
    protected override void Start()
    {
        base.Start();
        moveSpeed = Random.Range(moveSpeed - moveSpeed / 5f, moveSpeed + moveSpeed / 5f);
    }
}
