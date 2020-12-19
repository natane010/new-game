using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody EnemyRb;

    [SerializeField]
    private float moveSpeed;

    private Vector3 enemyPos;

    private float x;
    private float y;

    


    // Start is called before the first frame update
    void Start()
    {
        enemyPos = GetComponent<Rigidbody>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    void Move()
    {

    }
}
