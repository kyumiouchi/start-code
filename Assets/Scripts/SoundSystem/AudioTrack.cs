using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    /// <summary>
    /// AudioObject relates audioSource and all clips
    /// </summary>
    [Serializable]
    public class AudioTrack : MonoBehaviour
    {
        public AudioSource source;
        public AudioObject[] audio;
    }

    /// <summary>
    /// AudioObject relates audioType and audioClip
    /// </summary>
    [Serializable]
    public class AudioObject
    {
        public AudioType type;
        public AudioClip[] clip;
    }
    
    /// <summary>
    /// Audio type represents all the sounds used in the game.
    /// </summary>
    public enum AudioType
    {
        /// <summary>
        /// Button click sound
        /// </summary>
        BTN_Click,
        /// <summary>
        /// Sound of shot
        /// </summary>
        SFX_Shot_Gun,
        /// <summary>
        /// Sound of shot
        /// </summary>
        SFX_Shot_Laser,
        /// <summary>
        /// Sound of shot
        /// </summary>
        SFX_Get_Item,
        /// <summary>
        /// Music for Menu and Difficulty Menu Screen
        /// </summary>
        MSC_Menu,
        /// <summary>
        /// Music for Game
        /// </summary>
        MSC_Game,
        /// <summary>
        /// Music for Instruction
        /// </summary>
        MSC_Instruction
    }
}