using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public GameObject bulletPrefab;
    public int enemyHealth;
    public int enemySpeed;
    public float enemyFireRate;
    public float enemyDirectionX;
    public float enemyDirectionY;
    public int expValue;
}
