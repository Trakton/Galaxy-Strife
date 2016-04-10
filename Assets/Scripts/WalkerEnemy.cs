using UnityEngine;
using System.Collections;

public class WalkerEnemy : Enemy 
{
    public float orbitSpeed = 40;
    Vector3 orientation;

	void Start () 
    {
        Beggin();
        orbitSpeed = Random.RandomRange(orbitSpeed - orbitSpeed / 5f, orbitSpeed + orbitSpeed / 5f);
        moveSpeed = Random.RandomRange(moveSpeed - moveSpeed / 5f, moveSpeed + moveSpeed / 5f);
        orientation = Random.Range(0, 10) > 5 ? Vector3.forward : Vector3.back;
	}
	
	void Update ()
    {
        if (!active)
        {
            SlowlySpawn();
            return;
        }

        base.SeekPlayer();
        transform.RotateAround(PlayerController.Position, orientation, orbitSpeed * Time.deltaTime);
	}

    void OnDisable()
    {
        base.Disable();
    }
}
