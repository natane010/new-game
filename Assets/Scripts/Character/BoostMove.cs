using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoostMove : MonoBehaviour
{
    [SerializeField]
    Rigidbody objRb;

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

        
    }

    private void OnValidate()
    {
        float parSpeed = speed * 3.5f;
        foreach (var particle in _particleSystems)
        {
            ChangeSpeed(particle, parSpeed);
        }
    }
    private void ChangeSpeed(ParticleSystem particle, float speed)
    {
        var main = particle.main;
        main.simulationSpeed = speed;
    }
}
