using UnityEngine;
using System.Collections;

/// <summary>
/// Extends ship to define moving rules based on keyboard input.
/// </summary>
public class KeyboardDrivenShip : Ship 
{
	bool loadedGameover;

	protected override void Start(){
		loadedGameover = false;
		base.Start ();
	}

	void Update () 
    {
        if (Dead)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                if (GameVariables.GetPlayerLives() > 0)
                    Spawn();
                else
                    if (!loadedGameover)
                    {
                        Application.LoadLevelAdditive("Gameover");
                        loadedGameover = true;
                    }
            } 

            return;
        }

		base.Update ();
	}

	/// <summary>
	/// Rotates the ship towards mouse position.
	/// </summary>
    void RotateTowardMouse()
    {
        direction.x = Mathf.Lerp(direction.x, Input.GetAxis("Horizontal"), 5f * Time.deltaTime);
        direction.y = Mathf.Lerp(direction.y, Input.GetAxis("Vertical"), 5f * Time.deltaTime);

        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }

	/// <summary>
	/// Moves the ship for keyboard arrows direction.
	/// </summary>
    protected override void Move()
    {
		RotateTowardMouse ();
        Vector2 force = direction * moveSpeed * Time.deltaTime;
        body.AddForce(force);
        engine.enableEmission = Mathf.Abs(body.velocity.x) + Mathf.Abs(body.velocity.y) > 0.1f ? true : false;
    } 
}
