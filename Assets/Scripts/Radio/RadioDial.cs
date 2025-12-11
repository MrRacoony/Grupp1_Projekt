using UnityEngine;

public class RadioDial : MonoBehaviour
{

    private Vector3 mouse_pos;
    private Transform target; //Assign to the object you want to rotate
    private Vector3 object_pos;
    private float angle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.PlaySound(SoundManager.Sound.RadioStation1);
    }

    // Update is called once per frame
    void Update()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23F; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    private void OnMouseDown() {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.localRotation.eulerAngles.z+90));
    }
}
