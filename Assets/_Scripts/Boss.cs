using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int hp;

    public float speed;
    public float startingDistance;
    public float stopDistance;
    private Transform player;

    public GameObject spiker;
    public GameObject beetle;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject barrel;
    public GameObject bullet;

    public GameObject effect;

    public Vector2 leftSide;
    public Vector2 rightSide;

    public bool canActive;
    


    private float timeBtwSpiker;
    public float startTimeBtwSpiker;// Spawn time between spikers spawn

    private float timeBtwBeetle;
    public float startTimeBtwBeetle;//Spawn time between beetles 

    private float timeBtwShot;
    public float startTimeBtwnShot;//Time between his projectiles

   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 0)
        {
            Die();
        }
        if(Vector2.Distance(transform.position,player.position) > startingDistance)
        {
            canActive = false;
        }
        if (Vector2.Distance(transform.position, player.position) < startingDistance)
        {
            canActive = true;
        }

        if (timeBtwSpiker<= 0 && canActive)
        {
            Instantiate(spiker, spawn1.transform.position, Quaternion.identity);
            timeBtwSpiker = startTimeBtwSpiker;
           
        }
        else
        {
            timeBtwSpiker -= Time.deltaTime;
        }

        if (timeBtwBeetle <= 0 && canActive)
        {
            Instantiate(beetle, spawn2.transform.position, Quaternion.identity);
            timeBtwBeetle = startTimeBtwBeetle;
            
        }
        else
        {
            timeBtwBeetle -= Time.deltaTime;
        }

        if (timeBtwShot <= 0 && canActive)
        {
            Instantiate(bullet, barrel.transform.position, Quaternion.identity);
            timeBtwShot = startTimeBtwnShot;
           
        }
        else
        {
            timeBtwShot -= Time.deltaTime;
        }


        transform.position = new Vector2(Mathf.PingPong(Time.time, 5), transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp--;
    }

    void Die()
    {
        Destroy(gameObject);
       GameObject deathfx = Instantiate(effect, transform.position, Quaternion.identity);

        Destroy(deathfx, 5f);
    }
}
