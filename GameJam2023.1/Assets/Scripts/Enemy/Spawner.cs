using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private IEnumerator coroutine;
    //Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    public float spawnRate;
    public GameObject enemy;
    [SerializeField] private Transform parent;
    public bool isVertical;//Either spawns enemies that travel downward or move to the right.

    // Start is called before the first frame update
    void Start()
    {
        coroutine = Spawn(spawnRate);
        StartCoroutine(coroutine);
    }

    public void spawnFaster(float decreaseRate)
    {
        StopCoroutine(coroutine);
        spawnRate -= decreaseRate;
        coroutine = Spawn(spawnRate);
        StartCoroutine(coroutine);
    }
    IEnumerator Spawn(float waitTime)
    {
        while (true)
        {//-5.5 -> 5.5
            if (isVertical)
            {
                Instantiate(enemy, new Vector3(Random.Range(-5.5f, 5.5f), 7f, 0f), Quaternion.Euler(new Vector3(0, 0, 180)), parent);
            }
            else
            {
                Instantiate(enemy, new Vector3(-16f, Random.Range(-4f, 4.3f), 0f), Quaternion.Euler(new Vector3(0, 0, 180)), parent);
            }
            yield return new WaitForSeconds(waitTime);
        }
        //Shoots a bullet determined by the enemy type. Small, medium or large.
    }
}
