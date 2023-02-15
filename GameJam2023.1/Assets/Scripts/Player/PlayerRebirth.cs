using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRebirth : MonoBehaviour
{
    [HideInInspector] public PlayerMovement mScript;
    [HideInInspector] public PlayerShooting sScript;
    [HideInInspector] public PlayerCollision cScript;

    public float growth;
    public float lvl = 1;
    public float maxLvl = 20;

    void Awake()
    {
        mScript = GetComponent<PlayerMovement>();
        sScript = GetComponent<PlayerShooting>();
        cScript = GetComponent<PlayerCollision>();
    }

    void Update()
    {
        
    }

    public void Rebirth()
    {
        sScript.ATK = sScript.ATK + (growth);
        mScript.SPD = mScript.SPD + (growth / 5f);
        sScript.RNG = sScript.RNG + (growth / 2f);
    }
}
