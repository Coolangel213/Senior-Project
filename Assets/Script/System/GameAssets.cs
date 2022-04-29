using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i {
        get { 
            if(_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    public void DestroyAllAudioSources()
    {
        GameObject[] objectsInScene;
        GameObject[] hasAudio = null;

        objectsInScene = GameObject.FindObjectsOfType<GameObject>();

        for (int i = 0; i < objectsInScene.Length; i++)
        {
            if(objectsInScene[i].GetComponent<AudioSource>() != null)
                hasAudio[i] = objectsInScene[i];
        }

        if(hasAudio == null || hasAudio.Length == 0f)
            return;

        for (int i = 0; i < hasAudio.Length; i++)
        {
            Destroy(hasAudio[i]);
        }
    }   

    public SoundAudioClip[] soundAudioClipsArray;
    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
