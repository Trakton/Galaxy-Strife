using UnityEngine;
using System.Collections;

public class TrackCameraPosition : MonoBehaviour {

	void Start () {
	
	}
	void Update () {
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
	}
}
