using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [HideInInspector] public PlayerMovement mScript;
    [HideInInspector] public PlayerCollision cScript;
    [HideInInspector] public PlayerRebirth rScript;

    public float FRT = 5;
    private float fireTime;

    public Bullet pBullet;
    public GameObject bullet;

    void Awake()
    {
        mScript = GetComponent<PlayerMovement>();
        cScript = GetComponent<PlayerCollision>();
        rScript = GetComponent<PlayerRebirth>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fireTime <= 0f)
            {
                Bullet playerBullet = Instantiate(pBullet, transform.position, Quaternion.identity) as Bullet;
                playerBullet.atk = mScript.ATK;//Creates bullets and then gives the bullets the ATK value 
            }
        }
    }

    void FixedUpdate()
    {
        fireTime -= Time.deltaTime / FRT;
    }
}
