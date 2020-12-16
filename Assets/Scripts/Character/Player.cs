using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 20;
    [SerializeField]
    public float jumpPow;
    [SerializeField]
    public float rotateSpeed;
    

    [SerializeField]
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        if (Input.anyKey)
        {
            rb.AddForce(x, 0, z);
        }
        
    }
}
