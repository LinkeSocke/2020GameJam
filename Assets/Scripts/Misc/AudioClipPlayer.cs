using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioClipPlayer : MonoBehaviour
{
    [SerializeField] private AudioCollection collection = null;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();   
    }

    public void PlayRandomClip()
    {
        if (collection.audioClips.IsNullOrEmpty()) return;

        int rand = Mathf.RoundToInt(Random.Range(0f, (float)collection.audioClips.Count - 1));
        source.PlayOneShot(collection.audioClips[rand]);
    }
}
