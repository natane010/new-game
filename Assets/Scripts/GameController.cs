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
    GameObject whichGameObject;
    //List<GameObject> enemyList = new List<GameObject>();
    GameObject[] enemyObjList = new GameObject[3];
    Enemy[] enemyScList = new Enemy[3];
    AudioSource[] enemySoundList = new AudioSource[3];
    Vector3[] enemyStartPos = new Vector3[3];
    int enemyNum;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyObjList.Length; i++)
        {
            enemyObjList[i] = GameObject.Find($"Enemy ({i})");
            enemyScList[i] = enemyObjList[i].GetComponent<Enemy>();
            enemySoundList[i] = enemyObjList[i].GetComponent<AudioSource>();
            enemyStartPos[i] = enemyObjList[i].transform.position;
        }
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
                enemyScList[enemyNum].enemyHP = enemyScList[enemyNum].enemyMaxHp;
                whichGameObject.transform.position = enemyStartPos[enemyNum];
                foreach (var item in enemyScList[enemyNum].compositionObj)
                {
                    Destroy(item);
                }
                enemySoundList[enemyNum].enabled = false;
                enemyScList[enemyNum].compositionObj = new List<GameObject>();
                whichGameObject.SetActive(true);
                count = 0;
                enemySoundList[enemyNum].enabled = true;
                foreach (var item in enemyObjList)
                {
                    if (item.activeSelf == false)
                    {
                        isEnemy = true;
                        break;
                    }
                }
            }
        }
    }
    public void GetScore()
    {
        score += 100;
    }
    public void EnemyDead(GameObject a)
    {
        GetScore();
        enemyNum = 0;
        foreach (var item in enemyObjList)
        {
            if (item == a)
            {
                whichGameObject = a;
                isEnemy = true;
                break;
            }
            enemyNum++;
        }
    }
}
