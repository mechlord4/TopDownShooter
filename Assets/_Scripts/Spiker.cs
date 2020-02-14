using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiker : MonoBehaviour
{
    private Vector2 targetpos;
    private Transform player;
    public float speed;
    public float startingDistance;
    public GameObject north, south, east, west;

    public GameObject bullet;

    private int hp = 6;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,player.position) > startingDistance)
        {
            transform.position = this.transform.position;
        }
       else
        { 
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        if (hp == 0)
        {
            Die();
        }
    }


    void Die()
    {
        Destroy(gameObject);
        Instantiate(bullet, west.transform.position, west.transform.rotation);
        Instantiate(bullet, east.transform.position, east.transform.rotation);
        Instantiate(bullet, south.transform.position, south.transform.rotation);
        Instantiate(bullet, north.transform.position, north.transform.rotation);



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp--;
    }
}
