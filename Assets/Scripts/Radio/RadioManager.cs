using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class RadioManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> radioButtons;

    private int channel;

    private float freq1 = 45;
    private float freq2 = 230;
    private float freq3 = 80;
    private float freq4 = 300;
    private float freq5 = 150;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        channel = 0;
        SoundManager.PlaySound(SoundManager.Sound.RadioStation1);
        SoundManager.PlaySound(SoundManager.Sound.RadioStation2);
        SoundManager.PlaySound(SoundManager.Sound.RadioStation3);
        SoundManager.PlaySound(SoundManager.Sound.RadioStation4);
        SoundManager.PlaySound(SoundManager.Sound.RadioStation5);
        SoundManager.PlaySound(SoundManager.Sound.RadioDialStatic);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation2, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation4, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation5, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioDialStatic, 0f);
    }

    public void SetChannel(int input) {
        channel = input;
        for(int i=0; i<radioButtons.Count; i++) {
            radioButtons[i].transform.GetChild(0).gameObject.SetActive(false);
        }

        if(channel == 1) {
            transform.GetChild(0).gameObject.GetComponent<RadioDial>().SetChannelVolumes(freq1);
        }
        else if(channel == 2) {
            transform.GetChild(0).gameObject.GetComponent<RadioDial>().SetChannelVolumes(freq2);
        }
        else if(channel == 3) {
            transform.GetChild(0).gameObject.GetComponent<RadioDial>().SetChannelVolumes(freq3);
        }
        else if(channel == 4) {
            transform.GetChild(0).gameObject.GetComponent<RadioDial>().SetChannelVolumes(freq4);
        }
        else if(channel == 5) {
            transform.GetChild(0).gameObject.GetComponent<RadioDial>().SetChannelVolumes(freq5);
        }

    }

    public int GetChannel() {
        return channel;
    }

}
