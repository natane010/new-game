using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionNotify : MonoBehaviour
{
    public delegate void OnCollision(GameObject hitObj);

    OnCollision onCollision = null;

    public void Setup(OnCollision onCollision)
    {
        this.onCollision = onCollision;
    }

    private void OnParticleCollision(GameObject other)
    {
        onCollision(other);
    }
}
