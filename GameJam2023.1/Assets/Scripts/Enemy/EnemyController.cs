using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject butterflySpawner;
    public GameObject harpySpawner;
    public GameObject pegasusSpawner;
    public GameObject hydraSpawner;

    public GameObject phoenixBoss;


    public float spawnReference = 1f;
    public float decreaseRate;

    private int bossCount;

    // Start is called before the first frame update
    void Start()
    {
        bossCount = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            fasterSpawn();
        }


    }


    //When player dies and gain stats, the enemies spawn somewhat faster
    public void fasterSpawn()
    {
        Debug.Log("Enemy controlled");
        spawnReference -= decreaseRate;
        Debug.Log(spawnReference);
        if (butterflySpawner.gameObject.TryGetComponent<Spawner>(out Spawner butterflySpawn))
        {
            butterflySpawn.spawnFaster(decreaseRate);
        }
        if (harpySpawner.gameObject.TryGetComponent<Spawner>(out Spawner harpySpawn))
        {
            harpySpawn.spawnFaster(decreaseRate);
        }
        if (pegasusSpawner.gameObject.TryGetComponent<Spawner>(out Spawner pegasusSpawn))
        {
            pegasusSpawn.spawnFaster(decreaseRate);
        }
        if (hydraSpawner.gameObject.TryGetComponent<Spawner>(out Spawner hydraSpawn))
        {
            hydraSpawn.spawnFaster(decreaseRate);
        }

        if (spawnReference < (.8f - bossCount*0.1f) && spawnReference > (.7f - bossCount * 0.1f))
        {
            Instantiate(phoenixBoss, new Vector3(0, 10, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
            bossCount++;
        }


    }

}
