using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
