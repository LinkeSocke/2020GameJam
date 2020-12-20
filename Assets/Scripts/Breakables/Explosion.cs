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

    [SerializeField]
    private GameObject[] ignoreObjects = default;

    private bool isActive = true;
    public bool IsActive { get => isActive; set => isActive = value; }

    public void Explode()
    {
        if (isActive) { 
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach(Collider2D hit in colliders)
            {
                if (hit.GetComponent<Rigidbody2D>())
                {
                    bool contains = false;
                    foreach(GameObject obj in ignoreObjects)
                    {
                        if(hit.gameObject.Equals(obj)) {
                            contains = true;
                            break;
                        }
                    }

                    if (!contains)
                    {
                        hit.attachedRigidbody.AddExplosionForce(power, transform.position, radius, upwardsModifier);
                    }

                }
            }
        }
    }
}
