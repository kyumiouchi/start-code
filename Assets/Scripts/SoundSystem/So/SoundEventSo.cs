using UnityEngine;

namespace SoundSystem
{
    [CreateAssetMenu(menuName = "SoundSystem/Sound Event", fileName = "SFX_")]
    public class SoundEventSo : AudioEventSo
    {
        public void PlayOneShot(Vector3 position)
        {
            SetVariationValues();
            
            if (Clip == null) return;
            
            SoundManager.Instance.PlayOneShot(this, position);
        }
        
        public void Preview(AudioSource source)
        {
            SetVariationValues();
            
            if (Clip == null) return;
            
            source.clip = Clip;
            source.outputAudioMixerGroup = Mixer;
            source.volume = Volume;
            source.pitch = Pitch;
            
            source.Play();
        }
    }


}
