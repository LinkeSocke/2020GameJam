using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AUDIO_SOURCE_TYPE { GLASS, WOOD, KRIMSKRAMS, PAPER, NONE, METAL}

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }

    public AudioCollection collection;

    public AudioCollection glassCollection;
    public AudioCollection woodCollection;
    public AudioCollection krimskramsCollection;
    public AudioCollection paperCollection;
    public AudioCollection metalCollection;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public AudioClip GetRandomClip()
    {
        return GetRandomClip(collection);
    }

    public AudioClip GetRandomClip(AUDIO_SOURCE_TYPE type)
    {
        switch(type)
        {
            case AUDIO_SOURCE_TYPE.GLASS:
                if (glassCollection == null) goto default;
                return GetRandomClip(glassCollection);
            case AUDIO_SOURCE_TYPE.WOOD:
                if (woodCollection == null) goto default;
                return GetRandomClip(woodCollection);
            case AUDIO_SOURCE_TYPE.KRIMSKRAMS:
                if (krimskramsCollection == null) goto default;
                return GetRandomClip(krimskramsCollection);
            case AUDIO_SOURCE_TYPE.PAPER:
                if (paperCollection == null) goto default;
                return GetRandomClip(paperCollection);
            case AUDIO_SOURCE_TYPE.METAL:
                if (metalCollection == null) goto default;
                return GetRandomClip(metalCollection);
            default:
                return GetRandomClip();

        }
    }

    public AudioClip GetRandomClip(AudioCollection col)
    {
        int rand = Mathf.RoundToInt(Random.Range(0f, (float)col.audioClips.Count - 1));
        return col.audioClips[rand];
    }
}
