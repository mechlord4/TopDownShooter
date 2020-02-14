using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePos;
    Vector2 Screen;
    public int hp = 4;


    public float xoffset;
    public float yoffset;

    // Update is called once per frame
    void Update()
    {
        
        Screen = new Vector2(Camera.main.orthographicSize + xoffset, Camera.main.orthographicSize - yoffset);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Debug.Log(Screen.x);
        Debug.Log(Screen.y);
        print(Screen.y);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Boundaries();
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg - 90f;//Finds the theta of the player to a point in the world
        rb.rotation = angle;
    }


    void Boundaries()
    {
        if (transform.position.x > Screen.x)
        {
            transform.position = new Vector2(Screen.x, transform.position.y);
        }
        else if (transform.position.x < -Screen.x)
        {
            transform.position = new Vector2(-Screen.x, transform.position.y);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet") || collision.CompareTag("SpikeBulletE"))
        {
            hp--;
        }
    }
}
