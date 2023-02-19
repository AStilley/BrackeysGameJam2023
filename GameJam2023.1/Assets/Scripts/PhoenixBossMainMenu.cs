using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixBossMainMenu : MonoBehaviour
{
    private Rigidbody2D rb;
    public float enemySpeed;
    public bool down;


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!down)
        {
            rb.velocity = new Vector2(0, -1 * enemySpeed);
        }
        else
        {
            rb.velocity = new Vector2(1 * enemySpeed, 0);
        }


        if (transform.position.y < -10)
        {
            transform.position = new Vector2(-15, 0);
            transform.rotation = Quaternion.Euler(Vector3.forward * 270);
            down = true;
        }
        else if (transform.position.x > 15)
        {
            transform.position = new Vector2(0,10);
            transform.rotation = Quaternion.Euler(Vector3.forward * 180);
            down = false;
        }

    }
}
