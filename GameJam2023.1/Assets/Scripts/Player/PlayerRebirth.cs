using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRebirth : MonoBehaviour
{
    [HideInInspector] private PlayerMovement mScript;
    [HideInInspector] private PlayerShooting sScript;
    [HideInInspector] private PlayerCollision cScript;

    public float growth;
    public float lvl = 1;
    public float maxLvl = 20;
	private Animator animator;


    void Awake()
    {
        mScript = GetComponent<PlayerMovement>();
        sScript = GetComponent<PlayerShooting>();
        cScript = GetComponent<PlayerCollision>();
        animator = GetComponent<Animator>();
    }

    public void Rebirth()
    {
		animator.SetBool("dead", false);
		SoundManager.PlaySound("Rebirth", 3f, false);
        HealthSystem.heal(3f);
		PlayerMovement.CanMove = true;
        sScript.ATK = sScript.ATK + (growth / 2f);
        mScript.SPD = mScript.SPD + (growth / 5f);
        sScript.RNG = sScript.RNG + (growth / 2f);
    }
}
