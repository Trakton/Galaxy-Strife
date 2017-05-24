using UnityEngine;
using System.Collections;

public class FractionaryEnemy : Enemy
{
    public float minRotationSpeed = 80.0f;
    public float maxRotationSpeed = 120.0f;
    public float minMovementSpeed = 1.75f;
    public float maxMovementSpeed = 2.25f;
    private float rotationSpeed = 75.0f; // Degrees per second
    private float movementSpeed = 2.0f; // Units per second;
    private Transform target;
    private Quaternion qTo;

    void Start()
    {
        Begin();
        target = GameObject.Find("Player").transform;
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        movementSpeed = Random.Range(minMovementSpeed, maxMovementSpeed);
    }

    void Update()
    {
        if (!active)
        {
            SlowlySpawn();
            return;
        }
            
        Vector3 v3 = target.position - transform.position;
        float angle = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
        qTo = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, rotationSpeed * Time.deltaTime);
        v3.Normalize();
        transform.Translate( v3* movementSpeed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11f + GetComponent<Renderer>().bounds.size.x / 2, 11 - GetComponent<Renderer>().bounds.size.x / 2),
                                         Mathf.Clamp(transform.position.y, -7f + GetComponent<Renderer>().bounds.size.y / 2, 7f - GetComponent<Renderer>().bounds.size.y / 2), 0);
    }

    void OnDisable()
    {
        base.Disable();
    }
}