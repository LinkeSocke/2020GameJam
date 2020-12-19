using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BreakOnTouch : MonoBehaviour, IBreakable
{

    [SerializeField]
    private GameObject wholeObject;

    [SerializeField]
    private GameObject brokenObject;

    private bool broken = false;

    public void Break()
    {
        if (!broken)
        {
            Destroy(wholeObject);
            this.GetComponent<CapsuleCollider2D>().enabled = false;
            brokenObject.SetActive(true);
            var children = brokenObject.transform.GetComponentsInChildren<Transform>();
            System.Random rdm = new System.Random();
            foreach(var child in children)
            {
                Destroy(child.gameObject, rdm.Next(5, 10));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !broken)
        {
            Break();
        }
    }
}
