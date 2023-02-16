using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private IEnumerator coroutine;
    //Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    public float spawnRate;
    public GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        coroutine = Spawn(spawnRate);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Spawn(float waitTime)
    {
        while (true)
        {//-5.5 -> 5.5
            Instantiate(enemy, new Vector3(Random.Range(-5.5f,5.5f),7f, 0f), Quaternion.Euler(new Vector3(0,0,180)));
            yield return new WaitForSeconds(waitTime);
        }
        //Shoots a bullet determined by the enemy type. Small, medium or large.
    }
}
