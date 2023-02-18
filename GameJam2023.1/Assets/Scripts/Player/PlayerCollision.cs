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

        Debug.Log(collision.gameObject.name + "!");
    }
}
