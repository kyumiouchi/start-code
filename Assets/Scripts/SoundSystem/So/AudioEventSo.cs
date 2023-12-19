using UnityEngine;
using UnityEngine.Audio;

namespace SoundSystem
{
    public abstract class AudioEventSo : ScriptableObject
    {
        [Header("Audio Effect Settings")] 
        
        [SerializeField] private AudioType _type;
        [SerializeField] protected AudioClip[] _possibleClips = new AudioClip[0];
        [SerializeField] private AudioMixerGroup _mixer;
        [SerializeField] [MinMaxRange(0, 1)] protected RangedFloat _volume = new RangedFloat(.8f, .8f);
        [SerializeField] [MinMaxRange(0, 2)] protected RangedFloat _pitch = new RangedFloat(.85f, 0.95f);

        public AudioType Type => _type;
        public AudioClip[] PossibleClips => _possibleClips;
        protected int _clipIndex = 0;
        public AudioClip Clip => _possibleClips[_clipIndex];
        public AudioMixerGroup Mixer => _mixer;

        public float Volume { get; protected set; }
        public float Pitch { get; protected set; }
        
        protected void SetVariationValues()
        {
            _clipIndex = Random.Range(0, _possibleClips.Length);
            Volume = Random.Range(_volume.MinValue, _volume.MaxValue);
            Pitch = Random.Range(_pitch.MinValue, _pitch.MaxValue);
        }
    }
}
