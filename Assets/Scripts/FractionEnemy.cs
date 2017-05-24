using UnityEngine;
using System.Collections;

public class FractionEnemy : Enemy 
{
    public float rotateSpeed;
    float aceleration;

	void Start ()
    {
        Begin();
        rotateSpeed = Random.Range(rotateSpeed * 3 / 4, rotateSpeed);
        moveSpeed = Random.Range(moveSpeed * 3 / 4, moveSpeed);
	}
	
	void Update () 
    {
        if (!active)
        {
            SlowlySpawn();
            return;
        }

        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));

        base.SeekPlayer();
	}

    void OnDisable()
    {
        base.Disable();
    }
}
