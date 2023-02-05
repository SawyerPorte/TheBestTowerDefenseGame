using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager instance;

    [Header("Enemy Prefabs")]
    [SerializeField] GameObject Enemy_N;
    [SerializeField] GameObject Enemy_F;
    [SerializeField] GameObject Enemy_L;

    void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

}

