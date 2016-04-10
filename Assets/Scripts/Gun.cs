using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gun : MonoBehaviour 
{
    public GameObject bullet;
    public float shootRate;
    public float shootSpeed;
    public float angleOffset;
    AudioSource audio;

    static Queue<GameObject> bullets = new Queue<GameObject>();
    public float time;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
	
	void Update () 
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos -= transform.position;
        lookPos.Normalize();

        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        angle -= angleOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        time += Time.deltaTime;

        if(Input.GetButton("Fire1"))
             if (time >= shootRate)
                Shoot();
	}

    void Shoot()
    {
       
        GameObject newBullet = ObjectsPool.GetFromPool("bullet");
        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * shootSpeed * Time.deltaTime;
        time = 0;
    }

    public void ResetVariables(float shootRate, float shootSpeed, float angleOffset)
    {
        this.shootRate = shootRate;
        this.shootSpeed = shootSpeed;
        this.angleOffset = angleOffset;
        time = 0;
    }
}
