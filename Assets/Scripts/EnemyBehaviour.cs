using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{
    

    [Header("Enemy Prefabs")]
    [SerializeField] GameObject Enemy;
    [SerializeField] float health;
    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed = 1f;

    public float maxHealth;
    public int wpIndex = 0;
    private int lives = 5;
    public CursorBehavior cursorBehaviorScript;

    public Image HealthBar;
    private int lives = 5;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.transform.position = waypoints[wpIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            SceneManager.LoadScene(2);
        }

        HealthBar.fillAmount = health / maxHealth;
        //print(lives);
        Debug.Log(lives);
        Enemy_move();

        //if (Enemy.transform.position.x == 11.5f)
        
        
        if (lives < 1)
        {
            //Game Over
        }

    }

    void Enemy_move()
    {
        Enemy.transform.position = Vector2.MoveTowards(transform.position, waypoints[wpIndex].transform.position, moveSpeed * Time.deltaTime);
        if (Enemy.transform.position == waypoints[wpIndex].transform.position)
        {
            wpIndex++;
        }
        if (wpIndex == waypoints.Length)
        {
            Destroy(gameObject);
            lives -= 1;
        }
    }

    public void moveSpd()
    {
        moveSpeed = 5;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (health > 0 && collision.gameObject.tag != "Slow") 
        {
            health--;
        }
        if(health == 0)
        {
            GameObject.Find("Cursor").GetComponent<CursorBehavior>().AddMoney();
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Slow" && moveSpeed > 1)
        {
            moveSpeed -= 1f;
        }

       
    }

}
