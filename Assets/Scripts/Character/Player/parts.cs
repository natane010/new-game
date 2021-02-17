using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parts : MonoBehaviour
{   
    [SerializeField]
    Rigidbody a;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 b = a.velocity;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
