using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaking : MonoBehaviour, IBreakable
{
    [SerializeField]
    protected GameObject wholeObject;

    [SerializeField]
    protected GameObject brokenObject;

    protected bool broken = false;

    public virtual void Break()
    {
        if (!broken)
        {
            broken = true;

            Rigidbody2D body = GetComponent<Rigidbody2D>();
            if (body)
            {
                Destroy(body);
            }

            var colliders = GetComponents<Collider2D>();
            foreach(var collider in colliders)
            {
                Destroy(collider);
            }

            Destroy(wholeObject);
            brokenObject.SetActive(true);

            System.Random rdm = new System.Random();

            var children = brokenObject.transform.GetComponentsInChildren<Transform>();
            foreach (var child in children)
            {
                Destroy(child.gameObject, rdm.Next(5, 10));
            }

            Destroy(this.gameObject, 15);
        }
    }
}
