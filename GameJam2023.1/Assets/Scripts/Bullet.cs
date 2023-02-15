using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    public float speed = 5;

    private Rigidbody2D rb;

    public float atk;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.up * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Bullet hit something");
        //Debug.Log(atk + " Damage!");


        if (col.gameObject.TryGetComponent<EnemyTemplate>(out EnemyTemplate enemyCom))
        {
            enemyCom.TakeDamage(atk);
        }//If the collider is an Enemy, then the enemy takes damage.


        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Bullet hit something");
        //Debug.Log(atk + " Damage!");


        if (col.gameObject.TryGetComponent<EnemyTemplate>(out EnemyTemplate enemyCom))
        {
            enemyCom.TakeDamage(atk);
        }//If the collider is an Enemy, then the enemy takes damage.
        else if (col.gameObject.TryGetComponent<HealthSystem>(out HealthSystem player))
        {
            //enemyCom.TakeDamage(1);
        }//If the collider is the player, then the player takes damage.

        Destroy(gameObject);
    }

    public void setAtk(float atkVal)
    {//Testing out SendMessage function in PlayerShooting.cs
        atk = atkVal;
    }
}
