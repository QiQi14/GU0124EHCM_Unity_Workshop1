using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    Audio[] bgmArray;

    [SerializeField]
    Audio[] soundFXs;

    [SerializeField]
    AudioSource source;

    private static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static AudioManager Instance()
    {
        return instance;
    }

    public void PlayBGM(string name)
    {
        Audio bgm = Array.Find(bgmArray, x => x.audioName == name);

        if (bgm == null)
        {
            Debug.Log("Sound not found");
        } else
        {
            source.clip = bgm.audioClip;
            source.loop = true;
            source.Play();
        }
    }
}
