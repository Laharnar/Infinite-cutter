using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    [SerializeField] bool FulBackGroundMusic = true;
    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] List<AudioClip> audioClips;
    [SerializeField] AudioSource audioSource;
    
    private int CurrentSoundPlaying = 0;

    private void Start() {
        if (FulBackGroundMusic) {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        } else {
            audioSource.loop = false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (!FulBackGroundMusic && !audioSource.isPlaying) {
            audioSource.clip = audioClips[CurrentSoundPlaying];
            audioSource.Play();
            CurrentSoundPlaying++;
            CurrentSoundPlaying %= audioClips.Count;
        }
	}
}
