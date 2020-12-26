using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{

    public bool collider1 = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        collider1 = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        collider1 = false;
    }
}
