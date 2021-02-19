using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearRank : MonoBehaviour
{
    Text text;
    float nowScore;
    float time;
    float score;
    string rank;
    bool isClear;
    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        nowScore = GameController.score;
        time = GameController.time;
        isClear = GameController.result;
        float Hp = GameController.lastPlayerHP;
        score = (nowScore * Hp) / time;
        if (score < 400000 || isClear == false)
        {
            rank = "D";
        }
        else if (score < 600000)
        {
            rank = "C";
        }
        else if (score < 1000000)
        {
            rank = "B";
        }
        else if (score < 1600000)
        {
            rank = "A";
        }
        else
        {
            rank = "S";
        }

        text.text = "クリアランク：" + rank;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
