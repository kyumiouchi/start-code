using System.Collections;
using Game.Generic;
using SoundSystem;
using UnityEngine;

public class SoundManager : MonoBehaviourSingletonPersistence<SoundManager>
{
    [SerializeField] private int _startPoolSize = 5;

    private SoundPool _soundPool;
    protected override void Awake()
    {
        base.Awake();
        Initialize();
    }

    private void Initialize()
    {
        _soundPool = new SoundPool(transform, _startPoolSize);
    }

    public void PlayOneShot(SoundEventSo soundEventSo, Vector3 soundPosition = default)
    {
        if (soundEventSo.Clip == null) return; 

        AudioSource newSource = _soundPool.Get();
        SetValuesAtAudio(newSource, soundEventSo);
        newSource.transform.position = soundPosition == default? transform.position : soundPosition;
        
        newSource.Play();

        StartCoroutine(StopSound(newSource));
    }

    private void SetValuesAtAudio(AudioSource newSource, SoundEventSo soundEventSo)
    {
        newSource.clip = soundEventSo.Clip;
        newSource.outputAudioMixerGroup = soundEventSo.Mixer;
        newSource.volume = soundEventSo.Volume;
        newSource.pitch = soundEventSo.Pitch;
    }

    private IEnumerator StopSound(AudioSource audio)
    {
        audio.loop = false;

        var clipDuration = audio.clip.length;
        yield return new WaitForSeconds(clipDuration);
        audio.Stop();
        _soundPool.Return(audio);
    }
}
