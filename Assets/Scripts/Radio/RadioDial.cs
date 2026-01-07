using UnityEngine;

public class RadioDial : MonoBehaviour
{

    private Vector3 mousePos;
    private Vector3 objectPos;
    private float angle;
    private float previousAngle, currentAngle;
    private float maxVolume = 0.7f;
    private float staticVolume;
    private float currentFreq;

    [SerializeField] private float animTimer = 0f;

    [SerializeField] private float volume;
    [SerializeField] private SpriteRenderer light;
    [SerializeField] private Animator lightAnim;

    private AudioSource audioSource;

    private string animName;

    private bool isDragging;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDragging = false;
        animTimer = 0f;
    }

    void Update() {
        animTimer += Time.deltaTime;

        if(animTimer >= 3.0f) {
            animTimer = 0f;
            if(lightAnim != null && animName != null) {
                lightAnim.Play(animName);
            }
        }
    }

    private void OnMouseDown() {

    }

    private void OnMouseUp() {

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
        if(light != null) {
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
            animName = "RadioLightB7";

            SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation4, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation5, 0f);
        }
        else if(transform.parent.GetComponent<RadioManager>().GetChannel() == 3) {
            SoundManager.SetVolume(SoundManager.Sound.RadioDialStatic, staticVolume);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation3, volume);

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
            animName = "RadioLightF4";

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
            animName = "RadioLightD1";

            SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation2, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation4, 0f);
        }

        if(volume >= 0) {
            light.color = new Color(1f,1f,1f,1f);
        }
        else {
            light.color = new Color(1f,1f,1f,0f);
        }
    
    }

}
