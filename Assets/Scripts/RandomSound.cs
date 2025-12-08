using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public SoundManager.Sound[] audioClips;
    private SoundManager.Sound activeClip;
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
        SoundManager.PlaySound(activeClip);
    }
}
