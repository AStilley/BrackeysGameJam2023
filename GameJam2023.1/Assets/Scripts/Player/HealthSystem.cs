using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private static float health = 3f, totalHealth = 3f;

	[SerializeField] private Transform HealthCanvas, HealthCorePrefab;
    private static HealthSystem instance;
	
    public static float Health { get { return health; } }
    public static float MaxHealth { get { return totalHealth; } }
   
	void Awake()
	{
		if (instance == null) {  instance = FindObjectOfType<HealthSystem>(); }
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			heal(1f);
		}
		if(Input.GetKeyDown(KeyCode.G))
		{
			damage(1f);
		}
	}
    public static void damage(float amount)
    {
        if(health <= amount) { health = 0; }
		else { health -= amount; }
        instance.UpdateHealth();
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
		foreach(Transform childHeart in HealthCanvas)
		{
			Destroy(childHeart.gameObject);
		}
		for(int i = 0; i < health; i++)
		{
			RectTransform g = Instantiate(HealthCorePrefab, Vector3.zero, Quaternion.identity, HealthCanvas) as RectTransform;
			g.anchoredPosition = new Vector2(-500 + (50f * i), 245f);
		}
		Debug.Log("Player has " + health + " Health!");
	}

}
