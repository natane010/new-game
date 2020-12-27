using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            f.angularVelocity = -1 * Vector3.up * Mathf.PI;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            f.angularVelocity = Vector3.up * Mathf.PI;
        }
    }
}
