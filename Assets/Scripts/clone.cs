using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clone : MonoBehaviour
{
    [SerializeField]
    GameObject enemyObj;
    GameObject enemyNowObj;
    Enemy enemy;
    GameController gameController;
    List<GameObject> gameObjects;
    bool isAlive;
    float countTime;
    // Start is called before the first frame update
    void Start()
    {
        gameController = new GameController();
        enemy.target = gameController.playerBackPackRb;
        enemyNowObj = GameObject.Find("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        GameObject clone = Instantiate(enemyObj, this.transform.position, Quaternion.identity);
        enemy = clone.GetComponent<Enemy>();
        //enemy.target = gameController.playerBackPackRb;
        gameObjects.Add(clone);
    }
}
