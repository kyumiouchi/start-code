using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    public abstract class AudioListEventSo : ScriptableObject
    {
        [SerializeField] private AudioEventSo[] _soundEvents;

        /// <summary>
        /// Hashtable to access all audioClip
        /// </summary>
        private Dictionary<AudioType, AudioEventSo> _dicAudio = new Dictionary<AudioType, AudioEventSo>();

        private void OnEnable()
        {
            GenerateAudioTable();
        }

        private void GenerateAudioTable()
        {
            foreach (var audio in _soundEvents)
            {
                _dicAudio.TryAdd(audio.Type, audio);
            }
        }

        protected AudioEventSo GetAudio(AudioType type)
        {
            return _dicAudio[type];
        }
    }
}
