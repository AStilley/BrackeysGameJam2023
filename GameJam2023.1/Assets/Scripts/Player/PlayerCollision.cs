using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [HideInInspector] public PlayerMovement mScript;
    [HideInInspector] public PlayerShooting sScript;
    [HideInInspector] public PlayerRebirth rScript;

    [HideInInspector] public BoxCollider2D bc;

    public float EXP = 0;
    public float maxEXP = 10;

    void Awake()
    {
        mScript = GetComponent<PlayerMovement>();
        sScript = GetComponent<PlayerShooting>();
        rScript = GetComponent<PlayerRebirth>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        rScript.growth = (rScript.lvl / 5);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exp"))
        {
            EXP++;
            Destroy(collision.gameObject);
            EXPManager.AddXP(1);
            if (EXP >= maxEXP)
            {
                float expGain = maxEXP * 1.25f;
                EXP = 0;
                maxEXP = (int)expGain;
                if (rScript.lvl <= rScript.maxLvl)
                {
                    rScript.lvl++;
                }
            }
        }

<<<<<<< Updated upstream
        //Debug.Log(collision.gameObject.name + "!");
=======
<<<<<<< HEAD
        if (collision.gameObject.CompareTag("HP"))
        {
            HealthSystem.health++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("L"))
        {
            sScript.bullet = sScript.bulletL;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("M"))
        {
            sScript.bullet = sScript.bulletM;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("S"))
        {
            sScript.bullet = sScript.bulletS;
            Destroy(collision.gameObject);
        }

        Debug.Log(collision.gameObject.name + "!");
=======
        //Debug.Log(collision.gameObject.name + "!");
>>>>>>> a28c4066543fc7887b1f9fa117d485711b3dbca3
>>>>>>> Stashed changes
    }
}
