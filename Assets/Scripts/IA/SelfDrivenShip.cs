using UnityEngine;
using System.Collections;

/// <summary>
/// Move is defined by a series of artificial intelligence rules.
/// </summary>
public class SelfDrivenShip : Ship
{
	protected override void Move()
	{
		direction.x = 1;

		base.Move ();
	}
}
