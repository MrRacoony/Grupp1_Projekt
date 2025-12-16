using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;
    public void TriggerDialogue()
    {
        if (DialogueUI == null)
        {
            dialogueUI = FindAnyObjectByType<DialogueUI>();
        }

        if (dialogueUI == null)
        {
            Debug.LogError("DialogueUI not found in the scene.");
            return;
        }
        else if (dialogueObject == null)
        {
            Debug.LogError("DialogueObject is not assigned in the DialogueTrigger.");
            return;
        }
            DialogueUI.ShowDialogue(dialogueObject);
    }
}
