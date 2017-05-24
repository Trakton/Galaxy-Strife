using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour 
{
    SpriteRenderer renderer;
    public float fadeSpeed = 1f;
    float colorAlpha = 0f;

	void Start () 
    {
        renderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () 
    {
        colorAlpha = Mathf.Clamp(Mathf.Lerp(colorAlpha, 1, Time.deltaTime * fadeSpeed), 0, 1);
        renderer.color = new Color(255, 255, 255, colorAlpha);
	}
}
