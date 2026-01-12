using UnityEngine;

public class ClickTrigger : MonoBehaviour
{
    [SerializeField] private bool hasSound;
    [SerializeField] private SoundManager.Sound sound;
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
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
