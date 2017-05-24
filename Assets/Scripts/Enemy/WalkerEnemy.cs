using UnityEngine;
using System.Collections;

/// <summary>
/// Special enemy type that moves in a large orbit centered in player.
/// </summary>
public class WalkerEnemy : Enemy 
{
    public float orbitSpeed = 40;
    Vector3 orientation;

	protected override void Start () 
    {
        base.Start();
        orbitSpeed = Random.RandomRange(orbitSpeed - orbitSpeed / 5f, orbitSpeed + orbitSpeed / 5f);
        moveSpeed = Random.RandomRange(moveSpeed - moveSpeed / 5f, moveSpeed + moveSpeed / 5f);
        orientation = Random.Range(0, 10) > 5 ? Vector3.forward : Vector3.back;
	}

	/// <summary>
	/// Moves in the direction of the player but orbiting around it.
	/// </summary>
	protected override void SeekPlayer ()
    {
        base.SeekPlayer();
		transform.RotateAround(player.transform.position, orientation, orbitSpeed * Time.deltaTime);
	}
}
