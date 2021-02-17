using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static float score;
    [SerializeField]
    GameObject playerObj;
    public GameObject playerBackPack;
    public Rigidbody playerBackPackRb;
    [SerializeField]
    public GameObject enemyObj;
    public Enemy enemy;
    Vector3 startEnemyPos;
    public bool isEnemy;
    float count;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        enemyObj = GameObject.Find("Enemy");
        playerBackPack = GameObject.Find("Backpack");
        playerBackPackRb = playerBackPack.GetComponent<Rigidbody>();
        enemy = enemyObj.GetComponent<Enemy>();
        enemy.target = playerBackPackRb;
        startEnemyPos = enemyObj.transform.position;
        score = 0;
        isEnemy = false;
        count = 0.00f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemy)
        {
            count += Time.deltaTime;
            if (count < 5.00f)
            {
                isEnemy = false;
                enemy.enemyHP = 10000.000f;
                enemyObj.transform.position = startEnemyPos;
                enemyObj.SetActive(true);
                count = 0;
            }
        }
    }
    public void GetScore()
    {
        score += 100;
    }
    public void EnemyDead()
    {
        isEnemy = true;
    }
}
