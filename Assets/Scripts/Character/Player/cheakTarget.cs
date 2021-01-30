using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheakTarget : MonoBehaviour
{
    /// <summary>
    /// searching target
    /// </summary>
    GameObject targetObj;

    //[SerializeField]
    //string targetObjTag;

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

    public GameObject searchTag(GameObject nowTargetObj, string tagName)
    {
        

        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            nearDis = Vector3.Distance(obs.transform.position, nowTargetObj.transform.position);

            if (nearDis == 0 || subDis > nearDis)
            {
                subDis = nearDis;
                targetObj = obs;
                break;
            }
            else
            {
                targetObj = null;
            }
        }
        return targetObj;
    }

    public GameObject Search(GameObject now, string tag, float searchR)
    {
        searchTime += Time.deltaTime;

        if (searchTime > 0.0f)
        {
            subDis = searchR;

            nearTargetObj = searchTag(now, tag);

            searchTime = 0.0f;
        }

        return nearTargetObj;
    }

    public bool IsSearch(GameObject nowObj, string tag, float searchR, GameObject rayOrigin)
    {
        bool isHit = false;
        if (Search(nowObj, tag, searchR))
        {
            RaycastHit hit;

            GameObject target = Search(nowObj, tag, searchR);

            Vector3 objR = target.transform.position - rayOrigin.transform.position;
            //方向ベクトル
            Vector3 direction = objR.normalized;
            
            int layMask = LayerMask.GetMask(tag);
            if (Physics.Raycast(rayOrigin.transform.position, direction, out hit, searchR, layMask))
            {
                Debug.Log(target);
                Debug.Log(hit.transform.gameObject);
                if (hit.transform.gameObject.tag == target.tag)
                {
                    Debug.Log("c");
                    isHit = true;
                }
                else
                {
                    isHit = false;
                }
            }
            
        }
        return isHit;
    }
}
