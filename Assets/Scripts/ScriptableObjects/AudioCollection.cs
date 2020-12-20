using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioCollection", menuName = "ScriptableObjects/AudioCollection", order = 3)]
public class AudioCollection : ScriptableObject
{
    public List<AudioClip> audioClips = new List<AudioClip>();
}
