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

    // Start is called before the first frame update
    void Awake()
    {
        mScript = GetComponent<PlayerMovement>();
        sScript = GetComponent<PlayerShooting>();
        cScript = GetComponent<PlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Rebirth()
    {
        sScript.ATK = sScript.ATK * growth;
        mScript.SPD = mScript.SPD * growth;
        sScript.RNG = sScript.RNG * growth;
    }
}
