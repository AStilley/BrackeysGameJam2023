using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [HideInInspector] public PlayerMovement mScript;
    [HideInInspector] public PlayerCollision cScript;

    public float FRT = 5;
    private float fireTime;

    public GameObject bullet;

    void Awake()
    {
        mScript = GetComponent<PlayerMovement>();
        cScript = GetComponent<PlayerCollision>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fireTime <= 0f)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
        }
    }

    void FixedUpdate()
    {
        fireTime -= Time.deltaTime / FRT;
    }
}
