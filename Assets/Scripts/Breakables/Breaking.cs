using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Breaking : MonoBehaviour, IBreakable
{
    [SerializeField]
    protected GameObject wholeObject;

    [SerializeField]
    protected GameObject brokenObject;

    [SerializeField]
    protected Collider2D[] colliders;

    protected bool broken = false;

    public AUDIO_SOURCE_TYPE audioType = AUDIO_SOURCE_TYPE.NONE;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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

            foreach(var collider in colliders)
            {
                Destroy(collider);
            }

            Destroy(wholeObject);
            brokenObject.SetActive(true);

            System.Random rdm = new System.Random();

            //var children = brokenObject.transform.GetComponentsInChildren<Transform>();
            //foreach (var child in children)
            //{
            //    Destroy(child.gameObject, rdm.Next(5, 10));
            //}

            //Destroy(this.gameObject, 15);

            AddToBrokenList();

            var audioClip = AudioManager.Instance.GetRandomClip(audioType);
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void AddToBrokenList()
    {
        GameManager.Instance.AddBrokenObject(this);
    }
}
