using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{

    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private DialogueObject testDialogue;
    [SerializeField] private GameObject dialogueBox;

    private DialogueEffect dialogueEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueEffect = GetComponent<DialogueEffect>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        StartCoroutine(StepThroughDialogue(dialogueObject));
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
        dialogueBox.SetActive(false);
        tmpText.text = string.Empty;
    }
    private void OpenDialogueBox()
    {
        dialogueBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ShowDialogue(testDialogue);
        }
    }
}
