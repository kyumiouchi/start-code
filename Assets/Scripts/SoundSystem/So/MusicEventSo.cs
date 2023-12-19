using UnityEngine;

namespace SoundSystem
{
    [CreateAssetMenu(menuName = "SoundSystem/Music Event", fileName = "MUS_")]
    public class MusicEventSo : AudioEventSo
    {
        public void Play(float fadeTime = 1f)
        {
            SetVariationValues();
            
            MusicManager.Instance.PlayMusic(this, fadeTime);
        }
    }
}