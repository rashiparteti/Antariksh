using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
   
    public Transform playerShip;
    public GameObject Enemy;
    public float timer;
    public float moveSpeed = 5f;

 
    void Update()
    {
        timer += 1 * Time.deltaTime;

        if (timer > 4)
        {
            timer = 0;
            Make_Enemy();
        }

        if (playerShip != null)
        {
            MoveEnemies();
        }

        
    }

    public void Make_Enemy()
    {
        Instantiate(Enemy, new Vector3(Random.Range(-50, 50), Random.Range(-10, 20), Random.Range(350, 500)),Quaternion.identity);
    }

    void MoveEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            
            
            
            // Calculate direction towards player ship
            Vector3 direction = (playerShip.position - transform.position).normalized;
            
            // Look at the player ship
            enemy.transform.LookAt(playerShip);
            
            // Move towards the player ship
            enemy.transform.Translate(direction * moveSpeed * Time.deltaTime);
            
            
        }
        
        
    }

}

