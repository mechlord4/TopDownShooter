using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject boss;
    public GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }

        if (boss.GetComponent<Boss>().hp <= 0)
        {
            Victory();
        }
        if (player.GetComponent<PlayerMovement>().hp <= 0)
        {
            Dead();
        }
    }
    public void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ToGame()
    {
        
        SceneManager.LoadScene("Game");
    }

    public void Victory()
    {
        
        
            SceneManager.LoadScene("Victory");
        
        
    }
    
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

   public  void Dead()
    {

        
        
           SceneManager.LoadScene("Dead");
        
        
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
