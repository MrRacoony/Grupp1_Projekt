using UnityEngine;
using static SoundManager;

public class AudioRemoval : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioSource m_AudioSource;
    GameAssets.SoundAudioClip SoundAudioClip;
    void Start()
    {
        m_AudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_AudioSource.isPlaying)
        {
            foreach (GameAssets.SoundAudioClip audioAsset in GameAssets.instance.soundAudioClipArray)
            {
                if (audioAsset.audioClip == m_AudioSource.clip)
                {
                    StopSound(audioAsset.sound);
                }
            }
        }
    }
}
