using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController_Script : MonoBehaviour
{
    private AudioSource MusicType;
    public GameObject MusicEmmiter;
    public AudioClip[] MusicOptions;
    private AudioClip SelectedMusic;

    private void Start()
    {
        SelectedMusic = MusicOptions[Random.Range(0 , MusicOptions.Length)];
        MusicType = MusicEmmiter.GetComponent<AudioSource>();
        MusicType.clip = SelectedMusic;
        MusicEmmiter.SetActive(false);
        MusicEmmiter.SetActive(true);

    }


}
