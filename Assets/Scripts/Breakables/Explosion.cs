using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float power = 1.0f;
    [SerializeField]
    private float radius = 1.0f;
    [SerializeField]
    private float upwardsModifier = 1.0f;

    public void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D hit in colliders)
        {
            if (hit.GetComponent<Rigidbody2D>())
            {
                hit.attachedRigidbody.AddExplosionForce(power, transform.position, radius, upwardsModifier);
            }
        }
    }
}
