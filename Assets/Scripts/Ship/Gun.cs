using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A basic gun can shoot bullets. Can be extended to define rules for controlling and shooting the gun.
/// </summary>
public class Gun : MonoBehaviour {

	public GameObject bullet;
	public AudioSource audio;
	public float shootRate;
	public float shootSpeed;
	public float angleOffset;
	public float time;

	Queue<GameObject> bullets;

	protected virtual void Start()
	{
		audio = GetComponent<AudioSource>();
		bullets = new Queue<GameObject> ();
	}

	/// <summary>
	/// Gets a bullet from the inactive objects pool and apply a force on it to shoot.
	/// </summary>
	protected void Shoot()
	{
		GameObject bullet = ObjectsPool.GetFromPool("bullet");
		bullet.transform.position = transform.position;
		bullet.transform.rotation = transform.rotation;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.right * shootSpeed * Time.deltaTime;
		time = 0;
	}

	/// <summary>
	/// Changes gun specifications.
	/// </summary>
	/// <param name="shootRate">The gun Shoot rate.</param>
	/// <param name="shootSpeed">The gun Shoot speed.</param>
	/// <param name="angleOffset">The gun Angle offset.</param>
	public void ResetVariables(float shootRate, float shootSpeed, float angleOffset)
	{
		this.shootRate = shootRate;
		this.shootSpeed = shootSpeed;
		this.angleOffset = angleOffset;
		time = 0;
	}
}
