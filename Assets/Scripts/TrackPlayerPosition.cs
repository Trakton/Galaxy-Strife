using UnityEngine;
using System.Collections;

public class TrackPlayerPosition : MonoBehaviour 
{
    Rigidbody2D player;

	void Start () 
    {
		player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () 
    {
        transform.position += new Vector3(player.velocity.x, player.velocity.y, 0) * Time.deltaTime * 0.5f;
	}
}
