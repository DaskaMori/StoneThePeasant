using UnityEngine;

namespace MedievalMayhem.Scripts
{
    public class AudioManagerMm : MonoBehaviour
    {
        public static AudioManagerMm Instance;
        
        [Header("Audio Sources")]
        public AudioSource musicSource;
        public AudioSource sfxSource;

        [Header("Music Clips")] 
        public AudioClip menuMusic;
        public AudioClip gameMusic;

        [Header("SFX Clips")] 
        public AudioClip hammerSmashClip;
        public AudioClip hammerMissClip;
        public AudioClip targetHitClip;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            if (musicSource.clip == clip && musicSource.isPlaying)
                return;
            
            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.Play();
        }

        public void PlaySfx(AudioClip clip)
        {
            if (clip != null)
                sfxSource.PlayOneShot(clip);
        }
    }
}
