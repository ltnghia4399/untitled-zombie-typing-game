using UnityEngine.Audio;
using UnityEngine;

namespace My_UtilityScript
{
    [System.Serializable]
    public class Sounds
    {
        public string name;
        public AudioClip[] clips;

        public AudioMixerGroup audioMixer;

        [Range(0f, 1f)]
        public float volume;

        [Range(.1f, 3f)]
        public float pitch;

        public bool loop;

        [HideInInspector]
        public AudioSource source;
    }

}

