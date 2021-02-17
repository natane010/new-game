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
    AudioSource enemySound;
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
        enemySound = enemyObj.GetComponent<AudioSource>();
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
            if (count > 5.00f)
            {
                isEnemy = false;
                enemy.enemyHP = enemy.enemyMaxHp;
                enemyObj.transform.position = startEnemyPos;
                foreach (var item in enemy.compositionObj)
                {
                    Destroy(item);
                }
                enemySound.enabled = false;
                enemy.compositionObj = new List<GameObject>();
                enemyObj.SetActive(true);
                count = 0;
                enemySound.enabled = true;
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
