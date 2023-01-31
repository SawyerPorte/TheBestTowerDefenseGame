using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //Tutorial: https://www.youtube.com/watch?v=KsePvOltIKM

    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed = 1f;
    public int wpIndex = 0;

    private void Start()
    {
        transform.position = waypoints[wpIndex].transform.position;
    }

    private void Update()
    {
        movee();
    }

    void movee()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[wpIndex].transform.position, moveSpeed * Time.deltaTime);
        if(transform.position == waypoints[wpIndex].transform.position)
        {
            wpIndex++;
        }
            if(wpIndex == waypoints.Length - 1)
            {
                Destroy(gameObject);
            }
    }
}
