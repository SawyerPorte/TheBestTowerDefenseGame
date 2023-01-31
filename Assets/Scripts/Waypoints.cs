using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //Tutorial: https://www.youtube.com/watch?v=KsePvOltIKM

    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed = 1f;
    public int waypointIndex = 0;

    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        movee();
    }

    void movee()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        if(transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex++;
        }
            if(waypointIndex == waypoints.Length - 1)
            {
                Destroy(gameObject);
            }
    }
}
