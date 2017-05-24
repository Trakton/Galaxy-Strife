using UnityEngine;
using System.Collections;

public class SeekerEnemy : Enemy 
{
    void Start()
    {
        Begin();
        moveSpeed = Random.Range(moveSpeed - moveSpeed / 5f, moveSpeed + moveSpeed / 5f);
    }

    void Update ()
    {
        if (!active)
        {
            SlowlySpawn();
            return;
        }

        base.SeekPlayer();
	}

    void OnDisable()
    {
        base.Disable();
    }
}
