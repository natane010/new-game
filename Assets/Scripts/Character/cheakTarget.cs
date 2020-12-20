using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheakTarget : MonoBehaviour
{
    /// <summary>
    /// search target
    /// </summary>
    [SerializeField]
    GameObject targetObj = null;
    /// <summary>
    /// 探す距離
    /// </summary>
    float searchDis;
    /// <summary>
    /// 最も近いターゲット距離
    /// </summary>
    float nearDis;
    /// <summary>
    /// most near target object
    /// </summary>
    private GameObject nearTargetObj;
    /// <summary>
    /// search Time
    /// </summary>
    private float searchTime;

    //一時保管
    float subDis;

    // Start is called before the first frame update
    void Start()
    {
        subDis = searchDis;

        
    }

    // Update is called once per frame
    void Update()
    {

        searchTime += Time.deltaTime;

        if (searchTime > 0.0f)
        {
            subDis = 0.0f;

            nearTargetObj = searchTag(gameObject, targetObj.tag);

            searchTime = 0.0f;
        }


    }

    GameObject searchTag(GameObject nowTargetObj, string tagName)
    {
        

        foreach (var obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            nearDis = Vector3.Distance(obs.transform.position, nowTargetObj.transform.position);

            if (nearDis == 0 || subDis > nearDis)
            {
                subDis = nearDis;
                targetObj = obs;
            }
            else
            {
                targetObj = null;
            }
        }
        return targetObj;
    }
}
