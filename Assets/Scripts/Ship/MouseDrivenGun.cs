using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Extends a gun and let it be controlled by mouse.
/// </summary>
public class MouseDrivenGun : Gun 
{	
	/// <summary>
	/// Set target to be mouse position.
	/// </summary>
	protected override void Update()
	{
		target = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);

		base.Update ();
	}

	/// <summary>
	/// Shoot when mouse button is pressed.
	/// </summary>
	protected override void Shoot()
	{
		if (Input.GetButton ("Fire1"))
			base.Shoot ();
	}
}
