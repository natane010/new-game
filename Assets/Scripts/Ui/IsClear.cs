using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsClear : MonoBehaviour
{
    Text text;
    bool isClear;
    string result;
    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        isClear = GameController.result;
        if (isClear)
        {
            result = "Win";
        }
        else
        {
            result = "Failed";
        }
        text.text = result;
    }

    // Update is called once per frame
   
}
