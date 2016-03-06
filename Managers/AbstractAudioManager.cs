using UnityEngine;
using System.Collections.Generic;

public abstract class AbstractAudioManager : MonoBehaviourUndestroyableSingleton<AbstractAudioManager> {

    private AudioSource _AudioSource;

    protected virtual string _SOUNDS_PATH  { get { return "Audio/Sounds";  }}
    protected virtual string _AMBIENT_PATH { get { return "Audio/Ambient"; }}

    private Dictionary<int, AudioClip> _SoundDict;
    private Dictionary<int, AudioClip> _AmbientDict;

    void Awake() 
    {
        base.Awake(); if (_destroyed) return;

        SetAudioManagerReferences();
        LoadAudioClips();	

        SubscribeToEvents();
    }

    void OnDestroy()
    {
        UnsubscribeToEvents();
    }

    private void SetAudioManagerReferences() 
    {
        _AudioSource = GetComponent<AudioSource>();
    }
	
    private void LoadAudioClips() 
    {
        _SoundDict   = ResourcesIO.LoadAudioClips(_SOUNDS_PATH);
        _AmbientDict = ResourcesIO.LoadAudioClips(_AMBIENT_PATH);
    }

    protected abstract void SubscribeToEvents();
        //Events.OnAppStart += (() => PlayAmbient(0));

    protected abstract void UnsubscribeToEvents();
        //Events.OnAppStart -= (() => PlayAmbient(0));

    protected void PlayAmbient(int id) 
    {
        _AudioSource.clip = _AmbientDict[id];
        _AudioSource.loop = true;
        _AudioSource.Play();
    }

    protected void PlaySound(int id) 
    {
        _AudioSource.PlayOneShot(_SoundDict[id]);
    }

    protected void PlayRandomSound()
    {
        if (IsAnySoundLoaded())
        {
            int randomIndex = Random.Range(0, _SoundDict.Count);
            _AudioSource.PlayOneShot(_SoundDict[randomIndex]);
        }
    }

    private bool IsAnySoundLoaded()
    {
        int soundsAmount = _SoundDict.Count;
        return soundsAmount != 0;
    }
}
