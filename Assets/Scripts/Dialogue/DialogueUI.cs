using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{

    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private GameObject dialogueBox;

    private DialogueEffect dialogueEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueEffect = GetComponent<DialogueEffect>();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        if (dialogueEffect == null)
        {
            dialogueEffect = GetComponent<DialogueEffect>();
            ShowDialogue(dialogueObject);
        }
        else
        {
            Debug.Log("Starting Dialogue");
            StartCoroutine(StepThroughDialogue(dialogueObject));
        }
            
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        OpenDialogueBox();
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return dialogueEffect.Run(dialogue, tmpText);
            // Wait for user input to proceed to the next dialogue
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        CloseDialogueBox();

    }

    private void CloseDialogueBox()
    {
        dialogueBox.GetComponent<Image>().enabled = false;
        tmpText.text = string.Empty;
    }
    private void OpenDialogueBox()
    {
        Debug.Log("Activating");
        dialogueBox.GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
}
