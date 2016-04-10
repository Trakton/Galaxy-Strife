using UnityEngine;
using System.Collections;

public class GetPlayerName : MonoBehaviour 
{
    public Vector2 screenDivision;
    public string text;
    public GUIStyle style;

    static public string Text;
	
	void OnGUI () 
    {
        text = GUI.TextField(new Rect(Screen.width / screenDivision.x, Screen.height / screenDivision.y, 300, 20), text, style);

        if (text.Length > 16) text = text.Substring(0, 16);

        Text = text;
	}
}
