using UnityEngine.Audio;
using System;
using UnityEngine;

namespace My_UtilityScript
{

    public class AudioManager : Singleton<AudioManager>
    {
        public Sounds[] sounds;

        protected override void Awake()
        {
            base.Awake();
            foreach (Sounds s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clips[UnityEngine.Random.Range(0,s.clips.Length)];
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.outputAudioMixerGroup = s.audioMixer;
            }

        }

        private void Start()
        {
            PlayWithoutRandomPitch("Theme");

        }

        public AudioSource GetFirstAudioSource()
        {
            return GetComponent<AudioSource>();
        }


        /// <summary>
        /// Play Audio with random volume with pitch
        /// </summary>
        public void PlayWithRandomPitch(string name)
        {
            Sounds s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log("Sound " + name + " not found!");
                return;
            }

            s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volume / 2f, s.volume / 2f));
            s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitch / 2f, s.pitch / 2f)); ;


            s.source.Play();
        }



        /// <summary>
        /// Play Audio without random volume, pitch
        /// </summary>
        public void PlayWithoutRandomPitch(string name)
        {
            Sounds s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log("Sound " + name + " not found!");
                return;
            }


            s.source.volume = s.volume;
            s.source.pitch = s.pitch;


            s.source.Play();
        }

        public void PlayRandomSounds(string name)
        {
            Sounds s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log("Sound " + name + " not found!");
                return;
            }


            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.clip = s.clips[UnityEngine.Random.Range(0, s.clips.Length)];

            s.source.Play();
        }

        public void PullDownPitch(string name, float value)
        {
            Sounds s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log("Sound " + name + " not found!");
                return;
            }

            s.source.pitch = s.pitch;
        }

        public void Stop(string name)
        {
            Sounds s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log("Sound " + name + " not found!");
                return;
            }

            s.source.Stop();
        }
    }
}
