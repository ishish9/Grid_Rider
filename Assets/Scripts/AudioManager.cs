using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource MusicSource, SoundEffectsSource;
    [SerializeField] private AudioSource SoundEffectsSourceLooped1, SoundEffectsSourceLooped2, SoundEffectsSourceLooped3;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.PlayOneShot(clip);
    }
    public void PlaySoundEffects(AudioClip clip)
    {
        SoundEffectsSource.PlayOneShot(clip);
    }
    // Change Hover sound Pitch.
    public void HoverPitchChange(float pitch)
    {
        SoundEffectsSourceLooped1.pitch = pitch;
    }
    public void PlaySoundEffectsLooped1(AudioClip clip)
    {
        SoundEffectsSourceLooped1.clip = clip;
        SoundEffectsSourceLooped1.loop = true;
        SoundEffectsSourceLooped1.Play();
    }
    public void PlaySoundEffectsLooped2(AudioClip clip)
    {
        SoundEffectsSourceLooped2.clip = clip;
        SoundEffectsSourceLooped2.loop = true;
        SoundEffectsSourceLooped2.Play();
    }
    public void PlaySoundEffectsLooped3(AudioClip clip)
    {
        SoundEffectsSourceLooped3.clip = clip;
        SoundEffectsSourceLooped3.loop = true;
        SoundEffectsSourceLooped3.Play();
    }

    public void StopLoopedEffects()
    {
        SoundEffectsSourceLooped1.Stop();
        SoundEffectsSourceLooped2.Stop();
        SoundEffectsSourceLooped3.Stop();
    }
    public void PlaySoundDelayed(AudioClip clip, float delay)
    {
        SoundEffectsSource.clip = clip;
        SoundEffectsSource.PlayDelayed(delay);
    }
    // Control all Audio volume.
    public void MasterVolumeControl(float volumeLevel)
    {
        AudioListener.volume = volumeLevel;
    }

    public void SetMusicClip(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }
    public void ToggleMusic()
    {
        PlayerPrefs.SetInt("UserSetMusicSetting", 1);
        MusicSource.mute = !MusicSource.mute;       
        
        if (MusicSource.mute == true )
        {
            PlayerPrefs.SetInt("musicOnOff", 0);
        }
        else
        {
            PlayerPrefs.SetInt("musicOnOff", 1);
        }
    }

    public void ToggleSoundEffects()
    {
        SoundEffectsSource.mute = !SoundEffectsSource.mute;
    }

    public void MusicOn()
    {
        MusicSource.Play();
    }

    public void MusicOff()
    {
        MusicSource.Stop();
    }

    public void SoundEffectsOn()
    {
        SoundEffectsSource.Play();
    }

    public void SoundEffectsOff()
    {
        SoundEffectsSource.Stop();
    }
}

