using UnityEngine;

public class RadioDial : MonoBehaviour
{

    private Vector3 mousePos;
    private Vector3 objectPos;
    private float angle;
    private float previousAngle, currentAngle;
    private float maxVolume = 0.5f;
    private float staticVolume;

    private float freq1 = 45;
    private float freq2 = 230;
    private float freq3 = 80;
    private float freq4 = 300;
    private float freq5 = 150;
    private float currentFreq;

    [SerializeField] private float volume;

    private bool isDragging;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDragging = false;
        
    }

    private void OnMouseDown() {
        if(transform.parent.GetComponent<RadioManager>().GetChannel() == 1) {
            currentFreq = freq1;
        }
        else if(transform.parent.GetComponent<RadioManager>().GetChannel() == 2) {
            currentFreq = freq2;
        }
        else if(transform.parent.GetComponent<RadioManager>().GetChannel() == 3) {
            currentFreq = freq3;
        }
        else if(transform.parent.GetComponent<RadioManager>().GetChannel() == 4) {
            currentFreq = freq4;
        }
        else if(transform.parent.GetComponent<RadioManager>().GetChannel() == 5) {
            currentFreq = freq5;
        }
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
        currentAngle = transform.localRotation.eulerAngles.z;

        if(currentAngle > frequency) {
            volume = 0.5f + ((frequency-currentAngle)/50);
        }
        else if(currentAngle < frequency) {
            volume = 0.5f + ((currentAngle-frequency)/50);
        }

        if(volume > maxVolume) {
            volume = maxVolume;
        }
        else if(volume < 0) {
            volume = 0;
        }

        if(currentAngle > frequency) {
            staticVolume = ((frequency-currentAngle)/25) * -1.0f;
        }
        else if(currentAngle < frequency) {
            staticVolume = ((currentAngle-frequency)/25) * -1.0f;
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

            SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation2, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation5, 0f);
        }
        else if(transform.parent.GetComponent<RadioManager>().GetChannel() == 5) {
            SoundManager.SetVolume(SoundManager.Sound.RadioDialStatic, staticVolume);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation5, volume);

            SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation2, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation4, 0f);
        }
    
    }

}
