using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PolygonCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public PlayerShooting sScript;
    [HideInInspector] public PlayerCollision cScript;
    [HideInInspector] public PlayerRebirth rScript;

    public float SPD = 3;
    public float ATK = 1;
    public float RNG = 5;

    private Vector2 movement;

    [HideInInspector] public Rigidbody2D rb;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sScript = GetComponent<PlayerShooting>();
        cScript = GetComponent<PlayerCollision>();
        rScript = GetComponent<PlayerRebirth>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * SPD;
    }

}
