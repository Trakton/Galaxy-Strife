using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Extends ship to define moving rules based on keyboard input.
/// </summary>
public class KeyboardDrivenShip : Ship 
{
	/// <summary>
	/// Moves the ship for keyboard arrows direction.
	/// </summary>
    protected override void Move()
    {
		direction.x = Mathf.Lerp(direction.x, Input.GetAxis("Horizontal"), 5f * Time.deltaTime);
		direction.y = Mathf.Lerp(direction.y, Input.GetAxis("Vertical"), 5f * Time.deltaTime);

		base.Move ();
    } 
}
