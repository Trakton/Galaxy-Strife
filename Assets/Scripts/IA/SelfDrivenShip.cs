using UnityEngine;
using System.Collections;

/// <summary>
/// Move is defined by a series of artificial intelligence rules.
/// </summary>
public class SelfDrivenShip : Ship
{
	Risk risk;

	protected override void Start()
	{
		base.Start ();

		risk = new Risk ();
	}

	protected override void Move()
	{
		direction = MinimumRiskMovement ();

		base.Move ();
	}

	/// <summary>
	/// Calculates the risk of moving to each of the eight directions from the current position.
	/// </summary>
	/// <returns>The less risky direction for the ship to move.</returns>
	Vector2 MinimumRiskMovement()
	{
		Vector2 lessRiskyDirection = Vector2.zero;
		float minimumRisk = -1.0f;

		for (int i = -1; i <= 1; i++) {
			for (int j = -1; j <= 1; j++) {
				Vector2 direction = new Vector2 (i, j);
				direction.Normalize ();
				Vector2 currentPosition = new Vector2 (transform.position.x, transform.position.y);
				Vector2 newPosition = currentPosition + direction;
				float currentRisk = risk.Calculate (newPosition);
				if (minimumRisk < 0.0f || currentRisk < minimumRisk) 
				{
					minimumRisk = currentRisk;
					lessRiskyDirection = direction;
				}
			}
		}

		return lessRiskyDirection;
	}
}
