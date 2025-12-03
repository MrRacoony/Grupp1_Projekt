using UnityEngine;
using UnityEngine.Audio;
using static GameAssets;

public static class SoundManager
{

    public enum Sound
    {
        MenuTheme,
        PadlockInteract,
        PadlockUnlocked,
        Paperslide,
        Monster,
    }
    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.loop = LoopingSound(sound);
        audioSource.pitch = PitchSound(sound);
        audioSource.volume = GetVolume(sound);
        if (!audioSource.loop)
        {
            soundGameObject.AddComponent<AudioRemoval>();
        }
        audioSource.PlayOneShot(GetAudioClip(sound));

        // How to play sound : SoundManager.PlaySound(SoundManager.Sound."Name Of Sound");
    }

    public static void StopSound(Sound sound)
    {
        GameObject soundGameObject = GameObject.Find("Sound");
        AudioSource audioSource = soundGameObject.GetComponent<AudioSource>();
        audioSource.Stop();
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.instance.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
    private static bool LoopingSound(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip audioAsset in GameAssets.instance.soundAudioClipArray)
        {
            if (audioAsset.sound == sound)
            {
                return audioAsset.looping;
            }
                
        }

        return false;
    }

    private static float PitchSound(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip audioAsset in GameAssets.instance.soundAudioClipArray)
        {
            if (audioAsset.sound == sound)
            {
                if(audioAsset.pitch != 0)
                {
                    return audioAsset.pitch;
                }
                
            }
            
        }

        return 1;
    }

    public static float GetVolume(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip audioAsset in GameAssets.instance.soundAudioClipArray)
        {
            if (audioAsset.sound == sound)
            {
                return audioAsset.volume;
            }
        }
        return 1f; // default
    }

    public static void SetVolume(Sound sound, float newVolume)
    {
        foreach (GameAssets.SoundAudioClip audioAsset in GameAssets.instance.soundAudioClipArray)
        {
            if (audioAsset.sound == sound)
            {
                audioAsset.volume = Mathf.Clamp01(newVolume); // keep between 0–1
                return;
            }
        }
        Debug.LogWarning("Sound " + sound + " not found!");
    }

   

}
