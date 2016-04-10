using UnityEngine;
using System.Collections;

public class TrackMouse : MonoBehaviour 
{
    void Start()
    {
        Cursor.visible = false;
    }
	void Update () 
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
	}
}
