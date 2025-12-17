using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private DialogueUI dialogueUI;
    public void TriggerDialogue()
    {
        if (dialogueUI != null)
        {
            dialogueUI.ShowDialogue(dialogueObject);
        }
        else
        {
            dialogueUI = FindAnyObjectByType<DialogueUI>();
            TriggerDialogue();
        }
        
    }
}
