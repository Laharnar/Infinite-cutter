using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField] List<AudioClip> audioClips;
    [SerializeField] AudioSource audioSource;

    private int CurrentSoundPlaying = 0;
	
	// Update is called once per frame
	void Update () {
        if (!audioSource.isPlaying) {
            audioSource.clip = audioClips[CurrentSoundPlaying];
            audioSource.Play();
            CurrentSoundPlaying++;
            CurrentSoundPlaying %= audioClips.Count;
        }
	}
}
