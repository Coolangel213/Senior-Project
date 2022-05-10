using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound {
        jump,
        levelMusic,
        MainMenuMusic,
        button,
        Lose
    }
    
    public static void PlaySound(Sound sound)
    {
        GameObject soundObject = new GameObject("Sound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();

        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound ReSound)
    {
        foreach(GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipsArray)
        {
            if(soundAudioClip.sound == ReSound)
                return soundAudioClip.audioClip;
        }
        return null;
    }
}
