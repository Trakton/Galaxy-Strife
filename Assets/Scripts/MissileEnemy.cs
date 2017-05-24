using UnityEngine;
using System.Collections;

public class MissileEnemy : Enemy 
{
    Vector2 targetDirection;
    float targetRotation;
    string orientation;
    Vector2 direction;
    float rotation;
  

	void Start () 
    {
        Begin();

        if (Random.Range(0, 10) > 5)
        {
            targetRotation = 0;
            orientation = "horizontal";
            targetDirection = new Vector2(1, 0);
        }
        else
        {
            targetDirection = new Vector2(0, 1);
            targetRotation = 90;
            orientation = "vertical";
        }

        transform.rotation = Quaternion.AngleAxis(targetRotation * (targetDirection.x + targetDirection.y), Vector3.forward);
	}
	
	void Update () 
    {
        if (!active)
        {
            SlowlySpawn();
            return;
        }

        if (orientation == "horizontal")
        {
            if (transform.position.x < -8.5f)
            {
                targetDirection.x = 1;
                targetRotation = 0;
            }
            else if (transform.position.x > 8.5f)
            {
                targetDirection.x = -1;
                targetRotation = 180;
            }
        }

        else if (orientation == "vertical")
        {
            if (transform.position.y < -4.5f)
            {
                targetDirection.y = 1;
                targetRotation = 90;
            }
            else if (transform.position.y > 4.5f)
            {
                targetDirection.y = -1;
                targetRotation = 270;
            }
        }

        direction = new Vector2(Mathf.Lerp(direction.x, targetDirection.x, 1 * Time.deltaTime),
                                Mathf.Lerp(direction.y, targetDirection.y, 1 * Time.deltaTime));

        rotation = Mathf.Lerp(rotation, targetRotation, 5 * Time.deltaTime);
        GetComponent<Rigidbody2D>().velocity = direction * moveSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
	}

    void OnDisable()
    {
        base.Disable();
    }
}
