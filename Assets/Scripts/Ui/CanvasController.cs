using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    newPlayer playerSc;
    [SerializeField]
    GameObject hpTextObj;
    [SerializeField]
    GameObject boostTextObj;
    Text hpText;
    Text boostText;
    float lastHp;
    float lastBoost;
    // Start is called before the first frame update
    void Start()
    {
        hpText = hpTextObj.GetComponent<Text>();
        boostText = boostTextObj.GetComponent<Text>();
        playerSc = player.GetComponent<newPlayer>();
        lastHp = playerSc.maxPlayerHp * 1.00f;
        lastBoost = playerSc.boostMaxGauge * 1.00f;
        boostText.text = lastBoost + "/" + playerSc.boostMaxGauge;
        hpText.text = lastHp + "/" + playerSc.maxPlayerHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSc.boostGauge != lastBoost)
        {
            lastBoost = Mathf.Lerp(lastBoost * 1.0f, playerSc.boostGauge * 1.0f, Time.deltaTime);
            boostText.text = lastBoost + "/" + playerSc.boostMaxGauge;
        }
        if (playerSc.playerHP != lastHp)
        {
            lastHp = Mathf.Lerp(lastHp * 1.0f, playerSc.playerHP * 1.0f, Time.deltaTime);
            hpText.text = lastHp + "/" + playerSc.maxPlayerHp;
        }
    }
}
