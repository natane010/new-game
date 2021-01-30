using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody EnemyRb;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    Transform targetpos;
    [SerializeField]
    Transform bulletPos;

    bool player;
    bool playerBullet;

    private Vector3 enemyPos;

    private float x;
    private float y;

    cheakTarget cheakTarget = new cheakTarget();


    // Start is called before the first frame update
    void Start()
    {
        enemyPos = GetComponent<Rigidbody>().position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetpos);
        cheakPlayer();
        cheakBullet();
    }

    private void FixedUpdate()
    {
        
    }
    void Move()
    {

    }
    void boost()
    {

    }
    void Attack()
    {

    }
    void cheakPlayer()
    {
        player = cheakTarget.IsSearch(this.gameObject, "Player", 100, this.gameObject);
    }
    void cheakBullet()
    {
        playerBullet = cheakTarget.IsSearch(this.gameObject, "Bullet", 1000, this.gameObject);
    }
}
