using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_N_Behaviour : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    [SerializeField] GameObject Enemy_N;

    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed = 1f;
    public int wpIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Enemy_N.transform.position = waypoints[wpIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Nmove();
    }

    void Enemy_Nmove()
    {
        Enemy_N.transform.position = Vector2.MoveTowards(transform.position, waypoints[wpIndex].transform.position, moveSpeed * Time.deltaTime);
        if (Enemy_N.transform.position == waypoints[wpIndex].transform.position)
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
