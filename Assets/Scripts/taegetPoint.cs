using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taegetPoint : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    //Vector3 latepos;
    //float y;
    // Start is called before the first frame update
    void Start()
    {
        //y = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            //latepos = target.transform.position;
            //latepos.y = y;
            this.gameObject.transform.position = target.transform.position;
        }
    }
}
