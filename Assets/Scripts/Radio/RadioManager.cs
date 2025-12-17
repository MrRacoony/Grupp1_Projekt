using UnityEngine;

public class RadioManager : MonoBehaviour
{

    private int channel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        channel = 0;
        SoundManager.PlaySound(SoundManager.Sound.RadioStation1);
        SoundManager.PlaySound(SoundManager.Sound.RadioStation2);
        SoundManager.PlaySound(SoundManager.Sound.RadioStation3);
        SoundManager.PlaySound(SoundManager.Sound.RadioStation4);
        SoundManager.PlaySound(SoundManager.Sound.RadioStation5);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation2, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation4, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation5, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetChannel() {
        return channel;
    }

}
