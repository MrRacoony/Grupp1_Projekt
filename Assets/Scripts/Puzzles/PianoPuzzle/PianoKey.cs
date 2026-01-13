using Unity.VisualScripting;
using UnityEngine;

public class PianoKey : MonoBehaviour
{
    [SerializeField] private SoundManager.Sound pianoKey;
    private bool isPlaying = false;
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
        isPlaying = true;
        SoundManager.PlaySound(pianoKey);
    }

    public void SetPlaying(bool shouldPlay)
    {
        isPlaying = shouldPlay;
    }
    public bool IsPlaying()
    {
        return isPlaying;
    }
}
