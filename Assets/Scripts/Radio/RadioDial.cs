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
        SoundManager.PlaySound(SoundManager.Sound.RadioStation1);
        isDragging = false;
        radioStation = 1;
    }

    private void OnMouseDrag() {
        mousePos = Input.mousePosition;
        mousePos.z = 5.23F; //The distance between the camera and object
        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
        if(transform.localRotation.eulerAngles.z >= 0 && transform.localRotation.eulerAngles.z < 45 && radioStation != 1) {
            SoundManager.StopSound(SoundManager.Sound.RadioStation2);
            SoundManager.StopSound(SoundManager.Sound.RadioStation3);
            SoundManager.StopSound(SoundManager.Sound.RadioStation4);
            
            SoundManager.PlaySound(SoundManager.Sound.RadioStation1);
            radioStation = 1;
        }
        else if(transform.localRotation.eulerAngles.z >= 315 && transform.localRotation.eulerAngles.z < 360 && radioStation != 1) {
            SoundManager.StopSound(SoundManager.Sound.RadioStation2);
            SoundManager.StopSound(SoundManager.Sound.RadioStation3);
            SoundManager.StopSound(SoundManager.Sound.RadioStation4);
            
            SoundManager.PlaySound(SoundManager.Sound.RadioStation1);
            radioStation = 1;
        }
        else if(transform.localRotation.eulerAngles.z >= 45 && transform.localRotation.eulerAngles.z < 135 && radioStation != 2) {
            SoundManager.StopSound(SoundManager.Sound.RadioStation1);
            SoundManager.StopSound(SoundManager.Sound.RadioStation3);
            SoundManager.StopSound(SoundManager.Sound.RadioStation4);

            SoundManager.PlaySound(SoundManager.Sound.RadioStation2);
            radioStation = 2;
        }
        else if(transform.localRotation.eulerAngles.z >= 135 && transform.localRotation.eulerAngles.z < 225 && radioStation != 3) {
            SoundManager.StopSound(SoundManager.Sound.RadioStation1);
            SoundManager.StopSound(SoundManager.Sound.RadioStation2);
            SoundManager.StopSound(SoundManager.Sound.RadioStation4);

            SoundManager.PlaySound(SoundManager.Sound.RadioStation3);
            radioStation = 3;
        }
        else if(transform.localRotation.eulerAngles.z >= 225 && transform.localRotation.eulerAngles.z < 315 && radioStation != 4) {
            SoundManager.StopSound(SoundManager.Sound.RadioStation1);
            SoundManager.StopSound(SoundManager.Sound.RadioStation2);
            SoundManager.StopSound(SoundManager.Sound.RadioStation3);

            SoundManager.PlaySound(SoundManager.Sound.RadioStation4);
            radioStation = 4;
        }
    }
}
