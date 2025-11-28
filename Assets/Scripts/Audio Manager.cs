using UnityEngine;

public static class AudioManager
{

    public enum Sound
    {
        MenuTheme,

    }
    public static void PlaySound(Sound sound)
    {
        GameObject soundGO = new GameObject("Sound");
        AudioSource audioSource = soundGO.AddComponent<AudioSource>(); 
        audioSource.PlayOneShot(GetAudioClip(sound));

        // How to play sound : SoundManager.PlaySound(SoundManager.Sound."Name Of Sound");
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip audioAsset in GameAssets.instance.soundsArray)
        {
            if (audioAsset.sound == sound)
            {
                return audioAsset.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
}
