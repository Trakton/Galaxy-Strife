using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Extends a gun and let it be controlled by mouse.
/// </summary>
public class MouseDrivenGun : Gun 
{	
	/// <summary>
	/// Rotates the gun for facing mouse position.
	/// </summary>
	void TrackMouse()
	{
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
		lookPos -= transform.position;
		lookPos.Normalize();

		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		angle -= angleOffset;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	/// <summary>
	/// Shoots towards mouse position when mouse button is pressed.
	/// </summary>
	void Update () 
    {
		TrackMouse ();
        
        time += Time.deltaTime;

        if(Input.GetButton("Fire1"))
             if (time >= shootRate)
                Shoot();
	}
}
