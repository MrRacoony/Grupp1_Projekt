using UnityEngine;

public class ClickOnceTrigger : MonoBehaviour
{
    [SerializeField] private bool hasSound;
    [SerializeField] private SoundManager.Sound sound;
    private bool hasBeenClicked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (hasSound)
        {
            SoundManager.PlaySound(sound);
        }
        if (!hasBeenClicked)
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        hasBeenClicked = true;
    }
}
