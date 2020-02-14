using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float startingDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    public bool canShoot;

    private Transform player;
    public int hp = 5;
    public GameObject prefab;

    public Rigidbody2D rb;
    // Update is called once per frame

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        




        if (hp ==0)
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(effect,1f);
        }

        if (Vector2.Distance(transform.position, player.position) > startingDistance)
        {
            transform.position = this.transform.position;
            canShoot = false;
        }
       else if (Vector2.Distance(transform.position,player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            canShoot = true;
        }
        else if (Vector2.Distance(transform.position,player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            canShoot = true;
        }
        else if(Vector2.Distance(transform.position, player.position)< retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            canShoot = true;

        }

        if (timeBtwShots <= 0 && canShoot)
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = transform.position - player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90;
        rb.rotation = angle;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        hp--;
    }

    
    
    
}
