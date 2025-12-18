using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private DialogueUI dialogueUI;
    public Coroutine TriggerDialogue()
    {
        return dialogueUI.ShowDialogue(dialogueObject);
    }
}
