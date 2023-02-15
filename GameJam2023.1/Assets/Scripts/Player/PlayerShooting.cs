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
<<<<<<< Updated upstream
    public float ATK = 1;
    public float RNG = 5;

=======
>>>>>>> Stashed changes
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
                //gameObject.SendMessage("setAtk", ATK);//playerBullet.atk = ATK;//Creates bullets and then gives the bullets the ATK value
                Destroy(playerBullet, RNG / 5f);
            }
        }
    }

    void FixedUpdate()
    {
        fireTime -= Time.deltaTime / FRT;
    }
}
