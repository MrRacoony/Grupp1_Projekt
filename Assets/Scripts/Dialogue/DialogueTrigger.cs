using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private DialogueUI dialogueUI;
    public void TriggerDialogue()
    {
        dialogueUI.ShowDialogue(dialogueObject);
    }
}
