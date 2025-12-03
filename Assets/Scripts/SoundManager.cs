using UnityEngine;
using UnityEngine.Audio;
using static GameAssets;
using System.Collections.Generic;

public static class SoundManager
{
    public enum Sound
    {
        MenuTheme,
        PadlockInteract,
        PadlockUnlocked,
        Paperslide,
        Monster,
        ChestOpen,
        ItemPickup,
    }

    // Keep references to active AudioSources
    private static Dictionary<Sound, AudioSource> activeSources = new Dictionary<Sound, AudioSource>();

    public static void PlaySound(Sound sound)
    {
        // If we already have an AudioSource for this sound, just replay it
        if (activeSources.ContainsKey(sound))
        {
            activeSources[sound].Play();
            return;
        }

        // Otherwise create it once
        GameObject soundGameObject = new GameObject("Sound_" + sound.ToString());
        Object.DontDestroyOnLoad(soundGameObject);

        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.loop = LoopingSound(sound);
        audioSource.pitch = PitchSound(sound);
        audioSource.volume = GetVolume(sound);
        audioSource.clip = GetAudioClip(sound);

        audioSource.Play();

        activeSources[sound] = audioSource;
    }

    public static void StopSound(Sound sound)
    {
        if (activeSources.ContainsKey(sound))
        {
            activeSources[sound].Stop();
            // Do NOT destroy the GameObject � keep it alive for replay
        }
    }


    public static void SetVolume(Sound sound, float newVolume)
    {
        newVolume = Mathf.Clamp01(newVolume);

        // Update stored value
        foreach (GameAssets.SoundAudioClip audioAsset in GameAssets.instance.soundAudioClipArray)
        {
            if (audioAsset.sound == sound)
            {
                audioAsset.volume = newVolume;
                break;
            }
        }

        // Update active AudioSource
        if (activeSources.ContainsKey(sound))
        {
            activeSources[sound].volume = newVolume;
        }
    }

    public static float GetVolume(Sound sound)
    {
        if (activeSources.ContainsKey(sound))
        {
            return activeSources[sound].volume;
        }

        foreach (GameAssets.SoundAudioClip audioAsset in GameAssets.instance.soundAudioClipArray)
        {
            if (audioAsset.sound == sound)
            {
                return audioAsset.volume;
            }
        }
        return 1f; // default
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
            if (audioAsset.sound == sound && audioAsset.pitch != 0)
            {
                return audioAsset.pitch;
            }
        }
        return 1;
    }
}