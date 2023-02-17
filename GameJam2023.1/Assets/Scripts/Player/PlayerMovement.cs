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

    public static bool CanMove = true;
    public float SPD = 3;
    private Vector2 movement;

    [HideInInspector] public Rigidbody2D rb;
    private Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sScript = GetComponent<PlayerShooting>();
        cScript = GetComponent<PlayerCollision>();
        rScript = GetComponent<PlayerRebirth>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(CanMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Left", movement.x);
            animator.SetFloat("Right", movement.x);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * SPD;
    }

}
