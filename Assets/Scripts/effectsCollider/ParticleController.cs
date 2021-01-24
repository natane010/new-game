using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 150 * Time.deltaTime;
    }
    private void OnParticleCollision(GameObject other)
    {
        if (gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
            Instantiate(explosion, this.transform.position, Quaternion.identity);
        }
    }
}
