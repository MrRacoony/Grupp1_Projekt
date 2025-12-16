using UnityEngine;

public class AmbienceSelector : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.PlaySound(SoundManager.Sound.Ambience1);
        SoundManager.PlaySound(SoundManager.Sound.Ambience2);
        SoundManager.SetVolume(SoundManager.Sound.Ambience2, 0f);
    }
}
