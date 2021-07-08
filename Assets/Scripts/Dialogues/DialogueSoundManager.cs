using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// forces AudioSource component to sit on same GameObject
[RequireComponent(typeof(AudioSource))]
public class DialogueSoundManager : MonoBehaviour
{
    [Header("Clips")]
    [SerializeField] private AudioClip[] _clippedSoundClips = new AudioClip[0];
    [SerializeField] private AudioClip[] _normalClips       = new AudioClip[0];

    private Vector2 _pitchRange  = new Vector2(0.5f, 1.5f);
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _audioSource.loop        = false;
    }

    public void Play()
    {
        _audioSource.volume = 0.6f;
        _audioSource.pitch  = Random.Range(_pitchRange.x, _pitchRange.y);
        _audioSource.clip   = _clippedSoundClips[Random.Range(0, _clippedSoundClips.Length)];
        _audioSource.Play();
    }

    public void PlayNormal(int normalIndex)
    {
        _audioSource.volume = 1.0f;
        _audioSource.pitch  = 1.0f;
        _audioSource.clip   = _normalClips[normalIndex];
        _audioSource.Play();
    }

    public void StopPlay()
    {
        _audioSource.Stop();
    }
}
