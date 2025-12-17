using UnityEngine;

public class RadioDial : MonoBehaviour
{

    private Vector3 mousePos;
    private Vector3 objectPos;
    private float angle;

    private int radioStation;

    private bool isDragging;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDragging = false;
        
    }

    private void OnMouseDown() {
        SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation2, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation4, 0f);
        SoundManager.SetVolume(SoundManager.Sound.RadioStation5, 0f);
        SoundManager.PlaySound(SoundManager.Sound.RadioDialStatic);
    }

    private void OnMouseUp() {
        SoundManager.StopSound(SoundManager.Sound.RadioDialStatic);

        if(transform.localRotation.eulerAngles.z >= 0 && transform.localRotation.eulerAngles.z < 36) {            
            SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0.5f);
        }
        else if(transform.localRotation.eulerAngles.z >= 324 && transform.localRotation.eulerAngles.z < 360) {          
            SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0.5f);
        }
        else if(transform.localRotation.eulerAngles.z >= 36 && transform.localRotation.eulerAngles.z < 108) {
            SoundManager.SetVolume(SoundManager.Sound.RadioStation2, 0.5f);
        }
        else if(transform.localRotation.eulerAngles.z >= 108 && transform.localRotation.eulerAngles.z < 180) {
            SoundManager.SetVolume(SoundManager.Sound.RadioStation4, 0.5f);
        }
        else if(transform.localRotation.eulerAngles.z >= 180 && transform.localRotation.eulerAngles.z < 252) {
            SoundManager.SetVolume(SoundManager.Sound.RadioStation5, 0.5f);
        }
        else if(transform.localRotation.eulerAngles.z >= 252 && transform.localRotation.eulerAngles.z < 324) {
            SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0.5f);
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
    }
}
