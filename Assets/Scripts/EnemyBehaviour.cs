using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    [SerializeField] GameObject Enemy;
    [SerializeField] int health;
    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed = 1f;
    public int wpIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.transform.position = waypoints[wpIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_move();
    }

    void Enemy_move()
    {
        Enemy.transform.position = Vector2.MoveTowards(transform.position, waypoints[wpIndex].transform.position, moveSpeed * Time.deltaTime);
        if (Enemy.transform.position == waypoints[wpIndex].transform.position)
        {
            wpIndex++;
        }
        if (wpIndex == waypoints.Length - 1)
        {
            //lives--;

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health > 0 && collision.gameObject.tag != "Slow") 
        {
            health--;
        }
        if(health == 0)
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Slow" && moveSpeed > 1)
        {
            moveSpeed -= 1f;
        }
        
    }

}
