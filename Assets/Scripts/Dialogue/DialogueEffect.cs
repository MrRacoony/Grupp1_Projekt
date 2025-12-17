using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float typingSpeed = 50f;
    public Coroutine Run(string dialogue,TMP_Text textLabel)
    {
        return StartCoroutine(TypeText(dialogue, textLabel));
    }

    private IEnumerator TypeText(string dialogue, TMP_Text textLabel)
    {
        float t = 0;
        int charIndex = 0;

        while (charIndex < dialogue.Length)
        {
            t += Time.deltaTime * typingSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, dialogue.Length);
            textLabel.text = dialogue.Substring(0, charIndex);
            yield return null;
        }
        textLabel.text = dialogue;
        yield return null;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
