using UnityEngine;

public class LeftDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool dialogueTrigger = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SoundManager.PlaySound(SoundManager.Sound.DoorLocked);
        if (!dialogueTrigger)
        {
            dialogueTrigger = true;
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }
}
