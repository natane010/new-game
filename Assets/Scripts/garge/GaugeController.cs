using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    [SerializeField]
    GameObject imageHp;
    Image image;
    

    // Start is called before the first frame update
    void Start()
    {
        imageHp = GameObject.Find("HP");
        image = imageHp.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (image.fillAmount > 0.5f)
        {

            image.color = Color.red;

        }
        else if (image.fillAmount > 0.2f)
        {

            image.color = new Color(1f, 0.67f, 0f);

        }
        else
        {

            image.color = Color.white;

        }
    }
}
