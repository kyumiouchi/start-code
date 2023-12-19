using System.Collections;
using UnityEngine;

namespace SoundSystem
{
    public class MusicPlayer : MonoBehaviour
    {
        private AudioSource _audioSource = default;
        private float _sourceStartVolumes = 0f;

        private MusicEventSo _musicEventSo = null;
        private Coroutine _fadeVolumeCoroutine = null;
        private Coroutine _stopRoutine = null;

        private void Awake()
        {
            CreateLayerSources();
        }

        private void CreateLayerSources()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            _audioSource.loop = true;
        }

        public void Play(MusicEventSo musicEventSo, float fadeTime)
        {
            if (musicEventSo == null)
            {
                Debug.Log("No Music");
                return;
            }
            _musicEventSo = musicEventSo;
            _audioSource.volume = 0;
            _audioSource.clip = musicEventSo.Clip;
            _audioSource.outputAudioMixerGroup = musicEventSo.Mixer;
            _audioSource.Play();

            FadeVolume(MusicManager.Instance.Volume, fadeTime);
        }

        public void FadeVolume(float targetVolume, float fadeTime)
        {
            targetVolume = Mathf.Clamp(targetVolume, 0, 1);
            fadeTime = fadeTime < 0 ? 0 : fadeTime;

            if (_fadeVolumeCoroutine != null)
                StopCoroutine(_fadeVolumeCoroutine);
            _fadeVolumeCoroutine = StartCoroutine(LerpSourceSingleRoutine(targetVolume, fadeTime));
        }

        private IEnumerator LerpSourceSingleRoutine(float targetVolume, float fadeTime)
        {
            SaveSourceStartVolumes();

            float newVolume;
            float startVolume;

            for (float elapsedTime = 0; elapsedTime <= fadeTime; elapsedTime += Time.deltaTime)
            {
                    startVolume = _sourceStartVolumes;
                    newVolume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / fadeTime);
                    _audioSource.volume = newVolume;
                yield return null;
            }
            
            _audioSource.volume = targetVolume;
        }

        private void SaveSourceStartVolumes()
        {
            _sourceStartVolumes = _audioSource.volume;
        }

        public void Stop(float fadeTime)
        {
            if (_stopRoutine != null)
                StopCoroutine(_stopRoutine);
            _stopRoutine = StartCoroutine(StopRoutine(fadeTime));
        }

        private IEnumerator StopRoutine(float fadeTime)
        {
            if (_fadeVolumeCoroutine != null)
                StopCoroutine(_fadeVolumeCoroutine);
            
            _fadeVolumeCoroutine = StartCoroutine(LerpSourceSingleRoutine(0, fadeTime));

            yield return _fadeVolumeCoroutine;

            _audioSource.Stop();
        }
    }
}
