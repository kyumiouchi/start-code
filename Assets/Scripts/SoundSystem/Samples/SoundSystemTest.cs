using SoundSystem;
using UnityEngine;
using AudioType = SoundSystem.AudioType;

public class SoundSystemTest : MonoBehaviour
{
    [SerializeField] private MusicListEventSo _musicList;
    [SerializeField] private SoundListEventSo _sfxPlayer;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _musicList.Play(AudioType.MSC_Game,8f);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _musicList.Play(AudioType.MSC_Menu,8f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _musicList.Play(AudioType.MSC_Menu,2.5f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MusicManager.Instance.StopMusic(2.5f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _sfxPlayer.PlayOneShot(AudioType.SFX_Shot_Gun, transform.position);
        }
    }
}
