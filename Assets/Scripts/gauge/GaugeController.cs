using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    [SerializeField]
    GameObject gaugeHp;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject gaugeBo;
    Image imageHp;

    newPlayer playerSc;
    Image imageBo;

    float lastHp;
    float nowHp;
    float maxHp;
    float currentHp;
    float ratioHp;

    float nowBoost;
    float maxBoost;
    float currentBoost;
    float ratioBoost;

    // Start is called before the first frame update
    void Start()
    {
        playerSc = player.GetComponent<newPlayer>();
        imageHp = gaugeHp.GetComponent<Image>();
        imageBo = gaugeBo.GetComponent<Image>();
        lastHp = playerSc.playerHP * 1.000f;
        ratioHp = playerSc.playerHP / playerSc.maxPlayerHp * 1.000f;
        ratioBoost = playerSc.boostGauge / playerSc.boostMaxGauge * 1.000f;
        maxBoost = playerSc.boostMaxGauge * 1.000f;
    }

    // Update is called once per frame
    void Update()
    {
        nowHp = playerSc.playerHP * 1.000f;
        maxHp = playerSc.maxPlayerHp * 1.000f;
        currentHp = nowHp / maxHp * 1.000f;
        if (imageHp.fillAmount > 0.5f)
        {
            imageHp.color = Color.white;
        }
        else if (imageHp.fillAmount > 0.2f)
        {
            imageHp.color = new Color(1f, 0.67f, 0f);
        }
        else
        {
            imageHp.color = Color.red;
        }
        if (imageHp.fillAmount < currentHp)
        {
            imageHp.fillAmount -= 0.01f * Time.deltaTime;
        }
        nowBoost = playerSc.boostGauge * 1.000f;
        currentBoost = nowBoost / maxBoost * 1.000f;
        if (imageBo.fillAmount < currentHp)
        {
            imageBo.fillAmount -= 0.01f * Time.deltaTime;
        }
        if (imageBo.fillAmount > 0.5f)
        {
            imageBo.color = Color.white;
        }
        else if (imageBo.fillAmount > 0.2f)
        {
            imageBo.color = new Color(1f, 0.67f, 0f);
        }
        else
        {
            imageBo.color = Color.red;
        }
    }
    private void FixedUpdate()
    {
        if (ratioHp >= 0 && currentHp < ratioHp)
        {
            ratioHp -= 0.1f * Time.deltaTime;
        }
        imageHp.fillAmount = ratioHp;
        if (imageHp.fillAmount <= 0)
        {
            Lose();
        }
        if (ratioBoost >= 0 && currentBoost < ratioBoost)
        {
            ratioBoost -= 0.1f * Time.deltaTime;
        }
        else if (currentBoost > ratioBoost)
        {
            ratioBoost += 0.1f * Time.deltaTime;
        }
        imageBo.fillAmount = ratioBoost;
    }
    void Lose()
    {
        //シーン遷移
    }
}
