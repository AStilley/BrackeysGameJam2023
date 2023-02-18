using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [HideInInspector] public PlayerMovement mScript;
    [HideInInspector] public PlayerCollision cScript;
    [HideInInspector] public PlayerRebirth rScript;

    public static bool CanShoot = true;

    public float FRT = 5;
    private float fireTime;
    public float ATK = 1;
    public float RNG = 5;

    public Bullet pBullet;
    public GameObject bullet;

    void Awake()
    {
        mScript = GetComponent<PlayerMovement>();
        cScript = GetComponent<PlayerCollision>();
        rScript = GetComponent<PlayerRebirth>();
        CanShoot = true;
    }

    void Update()
    {
        if (CanShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (fireTime <= 0f)
                {
                    Bullet playerBullet = Instantiate(pBullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity) as Bullet;
                    //gameObject.SendMessage("setAtk", ATK);//
                    playerBullet.atk = ATK; //Creates bullets and then gives the bullets the ATK value
                    Destroy(playerBullet.gameObject, RNG / 5f);
                    fireTime = 2 / FRT;
                    SoundManager.PlaySound("PhoenixFire", 3f, true);
                }
            }
        }

    }

    void FixedUpdate()
    {
        fireTime -= Time.deltaTime;
    }
}
