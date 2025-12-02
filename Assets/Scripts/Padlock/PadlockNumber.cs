using UnityEngine;

public class PadlockNumber : MonoBehaviour
{

    [SerializeField] private int correctNum;

    private int currentNum;
    
    private bool isCorrect;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

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
        SoundManager.PlaySound(SoundManager.Sound.PadlockInteract); 
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
