using Unity.VisualScripting;
using UnityEngine;

public class PianoKey : MonoBehaviour
{
    [SerializeField] private SoundManager.Sound thisSound;
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
        SoundManager.PlaySound(thisSound);
    }
}
