using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives = 5;
    public float spawnInterval;

    [Header("Enemy Prefabs")]
    [SerializeField] GameObject Enemy_N;
    [SerializeField] GameObject Enemy_F;
    [SerializeField] GameObject Enemy_L;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
