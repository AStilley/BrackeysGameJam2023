using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemplate : MonoBehaviour
{
    //public GameObject enemyBullet;
    private float currHealth;

    private IEnumerator coroutine;
    private Rigidbody2D rb;
    public GameObject expObject;

    public float xSpeed;
    public float ySpeed;
    public GameObject bulletPrefab;

    public int enemyHealth;
    public float enemyFireRate;
    public int aiType;
    public float enemySpeed;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        currHealth = enemyHealth;
        //Stores the current health of the enemy. The enemy type holds the maximum health.
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Test");
        if (enemyFireRate > 0)
        {
            coroutine = Shoot(enemyFireRate);
            StartCoroutine(coroutine);
        }


        //The enemy shoots constantly every x seconds, where x is a float value assigned in the enemy type.
    }

    // Update is called once per frame
    void Update()
    {
        movement(aiType);
    }

    IEnumerator Shoot(float waitTime)
    {
        Debug.Log("Test");
        while (true)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(waitTime);
        }
        //Shoots a bullet determined by the enemy type. Small, medium or large.
    }
   
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //DEAL DAMAGE TO PLAYER
            die();
        }
    }


    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Player touched me");
        //This should cause a player to take damage
        

    }
    */

    public void TakeDamage(float amount)
    {
        Debug.Log("Enemy has taken Damage");
        currHealth -= amount;
        if (currHealth <= 0)
        {
            die();
        }//Things die when they are killed.
    }

    void die()
    {
        Instantiate(expObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void movement(int ai)
    {
        switch (ai)
        {
            case 0://Enemy moves straight down
                rb.velocity = new Vector2(0, -1 * ySpeed * (1f + 0.1f * enemySpeed));
                break;
            case 1://Enemy moves left
                rb.velocity = new Vector2(xSpeed* (1f + 0.1f * enemySpeed), 0);
                break;
            case 2:
                rb.velocity = new Vector2(-1* xSpeed* (1f + 0.1f * enemySpeed), 0);
                break;

        }



        //If the enemy moves down far enough, they are destroyed.
        if (transform.position.y < -10 || transform.position.x > 20 || transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }

}
