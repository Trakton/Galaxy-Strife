using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
     public float moveSpeed;
     protected bool active;
     SpriteRenderer renderer;

     float colorAlpha;

     protected virtual void Beggin()
     {
         renderer = GetComponent<SpriteRenderer>();
     }
   
     protected virtual void SeekPlayer()
     {
         Vector2 direction = PlayerController.Position - transform.position;
         direction.Normalize();
         direction = direction * moveSpeed * Time.deltaTime;
         GetComponent<Rigidbody2D>().velocity = direction;

         transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11f + renderer.bounds.size.x / 2, 11 - renderer.bounds.size.x / 2),
                                        Mathf.Clamp(transform.position.y, -7f + renderer.bounds.size.y / 2, 7f - renderer.bounds.size.y / 2), 0);
     }

     protected virtual void SlowlySpawn()
     {
         colorAlpha = Mathf.Clamp(colorAlpha += Time.deltaTime * 1.5f, 0, 1);
         renderer.color = new Color(255, 255, 255, colorAlpha);
        
         if (colorAlpha >= 1)
             active = true;
     }

     protected virtual void Disable()
     {
         active = false;
         colorAlpha = 0;
         GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, colorAlpha);
     }
}
