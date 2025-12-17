using UnityEngine;

public class RadioButton : MonoBehaviour
{

    [SerializeField] private int channelButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Started successfully.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        transform.parent.GetComponent<RadioManager>().SetChannel(channelButton);
        SoundManager.PlaySound(SoundManager.Sound.RadioClick);
        transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("Set channel to " + channelButton);
    }

}
