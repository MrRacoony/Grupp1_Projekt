using UnityEngine;

public static class SoundManager
{

    public enum Sound
    {
        MenuTheme,
        PadlockInteract,
        PadlockUnlocked,
    }
    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.loop = LoopingSound(sound);
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
            return audioAsset.looping;
        }

        return false;
    }
}
