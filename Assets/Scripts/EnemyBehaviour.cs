using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    [SerializeField] GameObject Enemy;

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
        Enemy_Nmove();
    }

    void Enemy_Nmove()
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
        //GameObject EnemyN = Instantiate(Enemy_N, spawnPosition, Quaternion.identity);
    }

}
