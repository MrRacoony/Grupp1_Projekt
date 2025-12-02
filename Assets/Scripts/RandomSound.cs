using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public GameAssets.SoundAudioClip[] audioClips;
    private GameAssets.SoundAudioClip activeClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayRandomSound();
        }
    }

    public void PlayRandomSound()
    {
        activeClip = audioClips[Random.Range(0, audioClips.Length)];
        SoundManager.PlaySound(activeClip.sound);
    }
}
