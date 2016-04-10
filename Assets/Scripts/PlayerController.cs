using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    ParticleSystem engine;
    BoxCollider2D box2d;
    public GameObject gun;
    public float moveSpeed = 10;
    static Vector3 position;
    static bool dead;
    float timer;
    float levelUpScore = 10000;
    Vector2 direction;
    bool loadedGameover;

    static public Vector3 Position
    {
        get { return position; }
    }

    static public bool Dead
    {
        get { return dead; }
    }

    void Start()
    {
        loadedGameover = false;
        dead = false;
        timer = 0;
        engine = GetComponentInChildren<ParticleSystem>();
        box2d = GetComponent<BoxCollider2D>();
    }

	void Update () 
    {
        position = transform.position;

        if (dead)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                if (GameVariables.GetPlayerLives() > 0)
                    Spawn();
                else
                    if (!loadedGameover)
                    {
                        Application.LoadLevelAdditive("Gameover");
                        loadedGameover = true;
                    }
            } 

            return;
        }

        RotateTowardMouse();
    
        if (GameVariables.GetPlayerScore() > levelUpScore)
            LevelUp();
	}

    void FixedUpdate()
    {
        if (dead)
            return;
        Move();
    }

    void RotateTowardMouse()
    {
        direction.x = Mathf.Lerp(direction.x, Input.GetAxis("Horizontal"), 5f * Time.deltaTime);
        direction.y = Mathf.Lerp(direction.y, Input.GetAxis("Vertical"), 5f * Time.deltaTime);

        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }

    void Move()
    {
        Vector2 force = direction * moveSpeed * Time.deltaTime;

        GetComponent<Rigidbody2D>().AddForce(force);

        engine.enableEmission = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) > 0.1f ? true : false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Die();

            string clone = "(Clone)";
            string colliderName = collider.name.Remove(collider.name.Length - clone.Length);
            ObjectsPool.PutInPool(colliderName, collider.gameObject);
        }
    }

    void Die()
    {
        box2d.enabled = false;
        GetComponent<Renderer>().enabled = false;
        engine.Stop();

        foreach (Gun gun in GetComponentsInChildren<Gun>())
        {
            gun.enabled = false;
        }

        GameObject deathExplosion = ObjectsPool.GetFromPool("playerDeathExplosion");
        deathExplosion.transform.position = transform.position;
        dead = true;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            string clone = "(Clone)";
            string enemyName = enemy.name.Remove(enemy.name.Length - clone.Length);
            int random = Random.Range(0, ObjectsPool.explosionsDic.Count);
            GameObject explosion = ObjectsPool.GetFromPool(ObjectsPool.explosionsDic[random]);
            explosion.transform.position = enemy.transform.position;
            ObjectsPool.PutInPool(enemyName, enemy);
        }

        GameVariables.DecreasePlayerLives();
    }

    void Spawn()
    {
        box2d.enabled = true;
        GetComponent<Renderer>().enabled = true;
        engine.Play();

        foreach (Gun gun in GetComponentsInChildren<Gun>())
        {
            gun.enabled = true;
        }

        GameObject spawnExplosion = ObjectsPool.GetFromPool("playerSpawnExplosion");
        spawnExplosion.transform.position = transform.position;
        dead = false;
        timer = 0;
    }

    void LevelUp()
    {
        GameObject newGun1 = Instantiate(gun, transform.position, Quaternion.identity) as GameObject;
        newGun1.transform.parent = transform;

        Gun[] playerGuns = GetComponentsInChildren<Gun>();

        float startAngle = playerGuns.Length * -2;
        float angleIncrease = playerGuns.Length;

        for (int i = 0; i < playerGuns.Length; i++)
        {
            playerGuns[i].angleOffset = startAngle + i * playerGuns.Length;
            playerGuns[i].time = 0f;
        }

        levelUpScore *= 10;
    }
}
