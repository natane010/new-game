using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoostMove : MonoBehaviour
{
    [SerializeField]
    Rigidbody objRb;

    Vector3 force;

    float speed;

    private List<ParticleSystem> _particleSystems;

    // Start is called before the first frame update
    void Start()
    {
        _particleSystems = gameObject.GetComponentsInChildren<ParticleSystem>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        speed = objRb.velocity.magnitude;
        
        float parSpeed = speed * 2.0f;
        foreach (var particle in _particleSystems)
        {
            ChangeSpeed(particle, parSpeed);
        }

        force = new Vector3(0, 0, speed / 2);
    }

    private void FixedUpdate()
    {
        objRb.AddForce(force, ForceMode.Force);
    }
    private void ChangeSpeed(ParticleSystem particle, float speed)
    {
        var main = particle.main;
        main.startSpeed = speed;
    }
}
