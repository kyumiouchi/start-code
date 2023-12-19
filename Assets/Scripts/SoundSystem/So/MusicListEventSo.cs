using UnityEngine;

namespace SoundSystem
{
    [CreateAssetMenu(menuName = "SoundSystem/Music List Event", fileName = "List_MUS_")]
    public class MusicListEventSo : AudioListEventSo
    {
        public void Play(AudioType type, float fadeTime)
        {
            var soundEvent = GetAudio(type);

            if (soundEvent == null) return;
            if (soundEvent is MusicEventSo) return;

            ((MusicEventSo)soundEvent).Play(fadeTime);
        }
    }
}
