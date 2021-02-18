using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    Text text;
    float nowScore;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        nowScore = GameController.score;
        time = GameController.time;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "スコアは" + nowScore * time;
    }
}
