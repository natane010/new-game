using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostBend : MonoBehaviour
{
    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deff = transform.position - lastPos;
        lastPos = transform.position;

        if (deff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(deff);
        }
    }
}
