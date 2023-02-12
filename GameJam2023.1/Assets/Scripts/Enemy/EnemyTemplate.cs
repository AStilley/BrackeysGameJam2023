using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemplate : MonoBehaviour
{
    //public GameObject enemyBullet;
    public Enemy enemy;
    private IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test");
        coroutine = Shoot(enemy.enemyFireRate);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {



       // Instantiate(enemy.bulletPrefab, transform.position, Quaternion.identity);
    }
    IEnumerator Shoot(float waitTime)
    {
        Debug.Log("Test");
        while (true)
        { 
            Instantiate(enemy.bulletPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
