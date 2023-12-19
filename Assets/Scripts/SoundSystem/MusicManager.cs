using Game;
using Game.Generic;
using SoundSystem;
using UnityEngine;

public class MusicManager : MonoBehaviourSingletonPersistence<MusicManager>
{
    [SerializeField] private float _volume = 0;

    private MusicPlayer _musicPlayer1;
    private MusicPlayer _musicPlayer2;

    private bool _isMusicPlayer1Playing = false;

    public MusicPlayer ActivePlayer => _isMusicPlayer1Playing ? _musicPlayer1 : _musicPlayer2;
    public MusicPlayer InActivePlayer => _isMusicPlayer1Playing ? _musicPlayer2 : _musicPlayer1;

    private MusicEventSo _activeMusicEventSo;
    public float Volume
    {
        get => _volume;
        private set
        {
            value = Mathf.Clamp(value, 0, 1);
            _volume = value;
        }
    }
    protected override void Awake()
    {
        base.Awake();
        SetupMusicPlayer();
    }

    private void SetupMusicPlayer()
    {
        _musicPlayer1 = gameObject.AddComponent<MusicPlayer>();
        _musicPlayer2 = gameObject.AddComponent<MusicPlayer>();
    }

    public void PlayMusic(MusicEventSo musicEventSo, float fadeTime)
    {
        if(musicEventSo == null) return;
        if(musicEventSo == _activeMusicEventSo) return;
        
        if(_activeMusicEventSo != null)
            ActivePlayer.Stop(fadeTime);
        
        _activeMusicEventSo = musicEventSo;
        _isMusicPlayer1Playing = !_isMusicPlayer1Playing;
        
        ActivePlayer.Play(musicEventSo, fadeTime);
    }

    public void StopMusic(float fadeTime)
    {
        if (_activeMusicEventSo == null)
            return;
        _activeMusicEventSo = null;
        ActivePlayer.Stop(fadeTime);
    }
}
