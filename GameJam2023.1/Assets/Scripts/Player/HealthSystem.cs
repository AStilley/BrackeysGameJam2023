using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
	public PlayerRebirth rScript;

	[SerializeField]
    private static float health = 3f, totalHealth = 3f;

	[SerializeField] private Transform HealthCanvas, HealthCorePrefab;
	[SerializeField] private Texture2D[] HealthSprites;

    private static HealthSystem instance;
	
    public static float Health { get { return health; } }
    public static float MaxHealth { get { return totalHealth; } }

	private Animator animator;


	void Awake()
	{
		if (instance == null) {  instance = FindObjectOfType<HealthSystem>(); }
		animator = GetComponent<Animator>();
	}

    public static void damage(float amount)
    {
		// health == 0 => GameOver state, skipping
		if(health != 0)
		{
			if(health <= amount) { health = 0; }
			else { health -= amount; }
			instance.UpdateHealth();
		}
    }

    public static void heal(float amount)
    {
        if (health < totalHealth)
        {
            health += amount;
            instance.UpdateHealth();
        }   
    }

    private void UpdateHealth()
	{
		for(int i = 0; i < MaxHealth; i++)
		{
			Transform h = HealthCanvas.GetChild(i);
			h.GetComponent<RawImage>().texture = (i+1 <= health ? HealthSprites[0] : HealthSprites[1]);
		}
		Debug.Log("Player has " + health + " Health!");

		if (health <= 0f)
		{
			rScript.Rebirth();
			animator.SetBool("dead", true);
			SoundManager.PlaySound("Death", .5f, false);
			PlayerMovement.CanMove = false;
			GameOverScreen.GameOver();
		}
	}

}
