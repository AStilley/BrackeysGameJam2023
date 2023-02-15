using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    public float speed = 5;

    private Rigidbody2D rb;

    public float atk = 1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.up * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Bullet hit " + col.gameObject.name);
        Debug.Log(atk + " Damage!");
        Debug.Log(col.gameObject.tag);

        if(col.gameObject.CompareTag("Player"))
        {
            HealthSystem.damage(atk);
        }
        if (col.gameObject.TryGetComponent<EnemyTemplate>(out EnemyTemplate enemyCom))
        {
            enemyCom.TakeDamage(atk);
        }   
        //If the collider is an Enemy, then the enemy takes damage.
        Destroy(gameObject);
    }

    public void setAtk(float atkVal)
    {//Testing out SendMessage function in PlayerShooting.cs
        atk = atkVal;
    }
}
