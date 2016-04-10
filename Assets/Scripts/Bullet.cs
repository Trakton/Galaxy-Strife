using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour 
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "StageCollider")
        {
            GameObject explosion = ObjectsPool.GetFromPool("bulletExplosion");
            explosion.transform.position = transform.position;
            ObjectsPool.PutInPool("bullet", this.gameObject);
        }

        else if (collider.tag == "Enemy")
        {
            string clone = "(Clone)";
            string colliderName = collider.name.Remove(collider.name.Length - clone.Length);
            int random = Random.Range(0, ObjectsPool.explosionsDic.Count);

            GameVariables.IncreasePlayeScore(GameVariables.GetEnemyScore(colliderName));
            GameObject explosion = ObjectsPool.GetFromPool(ObjectsPool.explosionsDic[random]);
            explosion.transform.position = transform.position;
            ObjectsPool.PutInPool(colliderName, collider.gameObject);
            ObjectsPool.PutInPool("bullet", this.gameObject);
        }
    }
}
