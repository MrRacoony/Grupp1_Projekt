using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{

    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private GameObject dialogueBox;

    private DialogueEffect dialogueEffect;
    private bool nextDialogue;
    private bool inDialogue;

    private List<Collider2D> interactables = new List<Collider2D>();
    private List<Canvas> canvases = new List<Canvas>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueEffect = GetComponent<DialogueEffect>();
    }

    public void ButtonPress(bool input)
    {
        nextDialogue = input;
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        if (dialogueEffect == null)
            dialogueEffect = GetComponent<DialogueEffect>();

        if (dialogueEffect == null)
        {
            Debug.LogError("DialogueEffect missing!");
            return;
        }

        StartCoroutine(StepThroughDialogue(dialogueObject));


    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        yield return new WaitForSeconds(0.1f);
        OpenDialogueBox();
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return dialogueEffect.Run(dialogue, tmpText);
            // Wait for user input to proceed to the next dialogue
            nextDialogue = false;
            yield return new WaitUntil(() => nextDialogue);
        }
        CloseDialogueBox();

    }

    private void CloseDialogueBox()
    {
        inDialogue = false;
        foreach (Collider2D interact in interactables)
        {
            interact.enabled = true;
        }
        foreach (Canvas c in canvases)
        {
            if (c != GetComponentInParent<Canvas>() && c.name != "PauseCanvas")
            {
                c.enabled = true;
            }
        }
        dialogueBox.SetActive(false);
        tmpText.text = string.Empty;
    }

    public bool IsInDialogue()
    {
        return inDialogue;
    }
    private void OpenDialogueBox()
    {
        interactables.Clear();
        canvases.Clear();

        interactables.AddRange(FindObjectsByType<Collider2D>(FindObjectsSortMode.None));
        canvases.AddRange(FindObjectsByType<Canvas>(FindObjectsInactive.Include, FindObjectsSortMode.None));

        inDialogue = true;
        foreach (Canvas c in canvases)
        {
            if (c != GetComponentInParent<Canvas>() && c.name != "PauseCanvas")
            {
                c.enabled = false;
            }
        }
        foreach (Collider2D interact in interactables)
        {
            interact.enabled = false;
        }
        Debug.Log("Activating");
        dialogueBox.SetActive(true);
    }

    // Update is called once per frame
}
