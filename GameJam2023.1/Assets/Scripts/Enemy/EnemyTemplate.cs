using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemplate : MonoBehaviour
{
    //public GameObject enemyBullet;
    private float currHealth;

    public Enemy enemy;
    private IEnumerator coroutine;
    private Rigidbody2D rb;
    public GameObject expObject;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        currHealth = enemy.enemyHealth;
        //Stores the current health of the enemy. The enemy type holds the maximum health.
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Test");
        coroutine = Shoot(enemy.enemyFireRate);
        StartCoroutine(coroutine);
        //The enemy shoots constantly every x seconds, where x is a float value assigned in the enemy type.
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + new Vector3(.05f * Mathf.Cos(5 * Time.time), -.0025f* enemy.enemySpeed, 0f);
    }
    IEnumerator Shoot(float waitTime)
    {
        Debug.Log("Test");
        while (true)
        { 
            GameObject bGameObject = Instantiate(enemy.bulletPrefab, transform.position, Quaternion.identity);
            bGameObject.GetComponent<Bullet>().atk = 1f;
            yield return new WaitForSeconds(waitTime);
        }
        //Shoots a bullet determined by the enemy type. Small, medium or large.
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Player touched me");
        //This should cause a player to take damage
    }


    public void TakeDamage(float amount)
    {
        Debug.Log("Enemy has taken Damage");
        currHealth -= amount;
        if (currHealth <= 0)
        {
            Instantiate(expObject,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }//Things die when they are killed.
    }
}
