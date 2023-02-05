using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    EnemyDetection enemyDetectionScript;

    
    
    void Start()
    {
       enemyDetectionScript = GetComponentInChildren <EnemyDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        //foreach(GameObject enemy in enemyDetectionScript.enemiesInRange)
        //{
        //    Vector2 lookAtPoint = enemy.transform.position;
        //    Vector2 distanceToEnemy = lookAtPoint - (Vector2)transform.position;
        //    float curDist = distanceToEnemy.magnitude;
        //    print(distanceToEnemy.magnitude);
        //    if (targetDistance == 0 || curDist < distanceToEnemy.magnitude)
        //    {
        //        //targetDistance = distanceToEnemy.magnitude;
        //        targetPoint = enemy.transform.position;
        //        distanceToTarget = targetPoint - (Vector2)transform.position;

        //    }
        //    print(targetDistance);
        //    Debug.DrawRay(transform.position, distanceToTarget, Color.red);



        //}
        if(enemyDetectionScript.enemiesInRange.Count > 0)
        {
            Vector2 lookAtPoint = enemyDetectionScript.enemiesInRange[0].transform.position;
            Vector2 distanceToEnemy = lookAtPoint - (Vector2)transform.position;
            Debug.DrawRay(transform.position, distanceToEnemy, Color.red);
        }
        
    }
   
}
