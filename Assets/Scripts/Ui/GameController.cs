using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
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
    GameObject whichGameObject;
    //List<GameObject> enemyList = new List<GameObject>();
    GameObject[] enemyObjList = new GameObject[3];
    Enemy[] enemyScList = new Enemy[3];
    AudioSource[] enemySoundList = new AudioSource[3];
    Vector3[] enemyStartPos = new Vector3[3];
    int enemyNum;
    float count;
    float lastScore;
    [SerializeField]
    GameObject scoreObj;
    Text scoreText;
    public static float time;
    public static float score;
    public static bool result;
    bool errorCheak = false;

    // Start is called before the first frame update
    void Start()
    {
        if (playerObj)
        {
            time = 0.00f;
            errorCheak = true;
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
            //enemySound = enemyObj.GetComponent<AudioSource>();
            //enemy = enemyObj.GetComponent<Enemy>();
            enemy.target = playerBackPackRb;
            //startEnemyPos = enemyObj.transform.position;
            score = 0;
            lastScore = score;
            scoreText = scoreObj.GetComponent<Text>();
            isEnemy = false;
            count = 0.00f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (errorCheak)
        {
            time += Time.deltaTime;
            if (score != lastScore)
            {
                scoreText.text = "Score:" + " " + score;
                lastScore = score;
            }
            if (score >= 3000)
            {
                result = true;
                //シーン遷移
                Invoke("SceneMove", 1.5f);
            }

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
    }
    public void GetScore()
    {
        score += 1000;
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
    public void Lose()
    {
        result = false;
        Invoke("SceneMove", 1.5f);
    }

    void SceneMove()
    {
        SceneManager.LoadScene("result");
    }
}
