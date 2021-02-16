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

    // Start is called before the first frame update
    void Start()
    {
        playerSc = player.GetComponent<newPlayer>();
        imageHp = gaugeHp.GetComponent<Image>();
        imageBo = gaugeBo.GetComponent<Image>();
        lastHp = playerSc.playerHP * 1.000f;
        ratioHp = playerSc.playerHP / playerSc.maxPlayerHp * 1.000f;
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
    }
    private void FixedUpdate()
    {
        if (ratioHp >= 0 && currentHp < ratioHp)
        {
            ratioHp -= 0.1f * Time.deltaTime;
        }
        imageHp.fillAmount = ratioHp;
    }
    void Lose()
    {
        //シーン遷移
    }
}
