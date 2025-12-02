using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public GameAssets.SoundAudioClip[] audioClips;
    private GameAssets.SoundAudioClip activeClip;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))//test function
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
