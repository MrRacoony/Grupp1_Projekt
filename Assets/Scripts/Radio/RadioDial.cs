using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class RadioDial : MonoBehaviour
{

    private Vector3 mousePos;
    private Vector3 objectPos;
    private float angle;
    private float previousAngle, currentAngle;
    private float maxVolume = 0.7f;
    private float staticVolume;
    private float currentFreq;

    [SerializeField] private AudioSource source = new AudioSource();

    [SerializeField] private float volume;
    [SerializeField] private SpriteRenderer light;
    [SerializeField] private Animator lightAnim, lightAnimB7, lightAnimF4, lightAnimD1;

    [SerializeField] private List<AudioSource> audioSources = new List<AudioSource>();
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    private string animName;

    private bool isDragging;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDragging = false;
    }

    void Update() {
        if(source != null) {
            if (source.time <= 0.1)
            {
                if (lightAnim != null) {
                    lightAnim.StopPlayback();
                    lightAnim.SetBool("Active", true);
                    /*Debug.Log(source.volume);
                    if (source.volume > 0)
                    {
                        
                    }
                    else
                    {
                        lightAnim.SetBool("Active", false);
                    }*/
                    //lightAnim.Play(animName);
                }
            }
        }
        
    }

    private void OnMouseDown() {

    }

    private void OnMouseUp() {

    }

    private void OnBecameVisible()
    {
        if(lightAnim != null) {
            lightAnim.SetBool("Active", false);
            SetChannelVolumes(currentFreq);
        }
        
    }

    private void OnMouseDrag() {
        mousePos = Input.mousePosition;
        mousePos.z = 5.23F; //The distance between the camera and object
        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle-90));

        SetChannelVolumes(currentFreq);       

    }

    public void SetChannelVolumes(float frequency) {
        
        if (light != null) {
            light.color = new Color(1f,1f,1f,0f);
        }
        
        currentAngle = transform.localRotation.eulerAngles.z;
        currentFreq = frequency;

        if(currentAngle > frequency) {
            volume = 0.65f + ((frequency-currentAngle)/25);
        }
        else if(currentAngle < frequency) {
            volume = 0.65f + ((currentAngle-frequency)/25);
        }

        if(volume > maxVolume) {
            volume = maxVolume;
        }
        else if(volume < 0) {
            volume = 0;
        }

        if(currentAngle > frequency) {
            staticVolume = ((frequency-currentAngle)/10) * -1.0f;
        }
        else if(currentAngle < frequency) {
            staticVolume = ((currentAngle-frequency)/10) * -1.0f;
        }

        if(staticVolume > maxVolume) {
            staticVolume = maxVolume;
        }
        else if(staticVolume < 0) {
            staticVolume = 0;
        }

        if(transform.parent.GetComponent<RadioManager>().GetChannel() == 1) {
            SoundManager.SetVolume(SoundManager.Sound.RadioDialStatic, staticVolume);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation1, volume);
            light = null;
            lightAnim = null;

            SoundManager.SetVolume(SoundManager.Sound.RadioStation2, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation4, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation5, 0f);
        }
        else if(transform.parent.GetComponent<RadioManager>().GetChannel() == 2) {
            SoundManager.SetVolume(SoundManager.Sound.RadioDialStatic, staticVolume);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation2, volume);
            light = GameObject.Find("RadioLightB7").GetComponent<SpriteRenderer>();
            lightAnim = GameObject.Find("RadioLightB7").GetComponent<Animator>();

            SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation4, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation5, 0f);
        }
        else if(transform.parent.GetComponent<RadioManager>().GetChannel() == 3) {
            SoundManager.SetVolume(SoundManager.Sound.RadioDialStatic, staticVolume);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation3, volume);
            light = null;
            lightAnim = null;

            SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation2, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation4, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation5, 0f);
        }
        else if(transform.parent.GetComponent<RadioManager>().GetChannel() == 4) {
            SoundManager.SetVolume(SoundManager.Sound.RadioDialStatic, staticVolume);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation4, volume);
            light = GameObject.Find("RadioLightF4").GetComponent<SpriteRenderer>();
            lightAnim = GameObject.Find("RadioLightF4").GetComponent<Animator>();

            SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation2, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation5, 0f);
        }
        else if(transform.parent.GetComponent<RadioManager>().GetChannel() == 5) {
            SoundManager.SetVolume(SoundManager.Sound.RadioDialStatic, staticVolume);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation5, volume);
            light = GameObject.Find("RadioLightD1").GetComponent<SpriteRenderer>();
            lightAnim = GameObject.Find("RadioLightD1").GetComponent<Animator>();

            SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation2, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation4, 0f);
        }

        if(light != null) {
            if(volume > 0) {
                light.color = new Color(1f,1f,1f,1f);
            }
            else {
                light.color = new Color(1f,1f,1f,0f);
            }
        }
        
        AudioClip clip;
        audioSources.Clear();
        audioSources.AddRange(GameObject.FindObjectsByType<AudioSource>(FindObjectsSortMode.None));
        if (source == null)
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                if (audioClips.Contains(audioSources[i].clip))
                {
                    source = audioSources[i];
                    clip = source.clip;
                    break;
                }
            }
        }
        for (int i = 0; i < audioSources.Count; i++)
        {
            if (audioClips.Contains(audioSources[i].clip))
            {
                if (audioSources[i].volume > source.volume)
                {
                    source = audioSources[i];
                    clip = source.clip;
                }
            }
        }

    }

    public void ResetLightAnim() {
        if(lightAnim != null) {
            lightAnim.SetBool("Active", false);
        }
    }

}
