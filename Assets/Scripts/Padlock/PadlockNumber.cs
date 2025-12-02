using UnityEngine;

public class PadlockNumber : MonoBehaviour
{

    [SerializeField] private int correctNum;
    [SerializeField] private AudioClip scrollSound;

    private int currentNum;
    
    private bool isCorrect;

    private Animator anim;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        currentNum = 0;
        if(currentNum == correctNum) {
            isCorrect = true;
        }
        else {
            isCorrect = false;
        }
    }

    public bool GetIsCorrect() {
        return isCorrect;
    }

    public void SetNum(int num) {
        audioSource.PlayOneShot(scrollSound, 1f);
        currentNum += num;
        if(currentNum == 10) {
            currentNum = 0;
        }
        if(currentNum == -1) {
            currentNum = 9;
        }

        anim.SetInteger("currentNum", currentNum);

        if(currentNum == correctNum) {
            isCorrect = true;
            Debug.Log("Unlocked padlock!");
        }
        else {
            isCorrect = false;
        }
    }
}
