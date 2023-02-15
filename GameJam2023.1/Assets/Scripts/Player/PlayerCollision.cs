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

    void OnTriggerEnter2D(Collider2D col)
    {
<<<<<<< Updated upstream
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

        rScript.growth = (rScript.lvl / 5) + 1f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Exp"))
        {
            EXP++;
            Destroy(collision.gameObject);
        }
=======
        Debug.Log(col.gameObject.name + "!");
>>>>>>> Stashed changes
    }
}
