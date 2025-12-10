using UnityEngine;

public class RadioDial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.PlaySound(SoundManager.Sound.RadioStation1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.localRotation.eulerAngles.z+90));
    }
}
