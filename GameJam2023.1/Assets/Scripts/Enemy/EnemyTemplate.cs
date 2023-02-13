using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemplate : MonoBehaviour
{
    //public GameObject enemyBullet;
    private int currHealth;

    public Enemy enemy;
    private IEnumerator coroutine;

    void Awake()
    {


        currHealth = enemy.enemyHealth;
        //Stores the current health of the enemy. The enemy type holds the maximum health.
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Test");
        coroutine = Shoot(enemy.enemyFireRate);
        StartCoroutine(coroutine);
        //The enemy shoots constantly every x seconds, where x is a float value assigned in the enemy type.
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
        //Things die when they are killed.





        transform.position = transform.position + new Vector3(.05f * Mathf.Cos(5 * Time.time), -.0025f* enemy.enemySpeed, 0f);



    }
    IEnumerator Shoot(float waitTime)
    {
        Debug.Log("Test");
        while (true)
        { 
            Instantiate(enemy.bulletPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
        //Shoots a bullet determined by the enemy type. Small, medium or large.
    }
}