using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;
    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    public void SetVolume(float _value)
    {
        if (_value < 1) _value = .001f;
        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);

        float normalized = _value / 100f;
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(normalized) * 20f);

        SoundManager.SetGlobalVolume(normalized);
    }
    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float _value)
    {
        soundSlider.value = _value;
    }
}
