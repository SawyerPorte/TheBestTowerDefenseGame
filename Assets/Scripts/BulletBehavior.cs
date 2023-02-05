using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.x > 10f || transform.position.x < -20f || transform.position.y > 15f || transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }
}
