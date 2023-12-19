using UnityEngine;

namespace SoundSystem
{
    [CreateAssetMenu(menuName = "SoundSystem/Sound List Event", fileName = "List_SFX_")]
    public class SoundListEventSo : AudioListEventSo
    {
        public void PlayOneShot(AudioType type, Vector3 position)
        {
            var soundEvent = GetAudio(type);

            if (soundEvent == null) return;
            if (soundEvent is SoundEventSo) return;

            ((SoundEventSo)soundEvent).PlayOneShot(position);
        }
    }
}
